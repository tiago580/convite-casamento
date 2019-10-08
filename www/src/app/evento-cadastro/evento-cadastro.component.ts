import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import * as moment from 'moment';
import { Evento } from 'src/evento/evento';
import { Convidado } from 'src/evento/convidado';
import { Status } from 'src/evento/status';
import { EventoService } from 'src/evento/evento.service';

@Component({
  selector: 'app-evento-cadastro',
  templateUrl: './evento-cadastro.component.html',
  styleUrls: ['./evento-cadastro.component.scss']
})
export class EventoCadastroComponent implements OnInit {

  title: string;
  dataMinima: Date;
  evento: Evento;
  convidados: Convidado[] = [];

  formCadastroEvento = new FormGroup({
    nome: new FormControl('', [Validators.required, Validators.maxLength(255)]),
    data: new FormControl(new Date(), [Validators.required])
  });

  formAddConvidado = new FormGroup({
    nome: new FormControl('', [Validators.required, Validators.maxLength(255)])
  });
 
  constructor(
    public bsModalRef: BsModalRef,
    private localeService: BsLocaleService,
    private toastr: ToastrService,
    private eventoService: EventoService) {

    this.dataMinima = new Date();
    this.localeService.use('pt-br');
  }
 
  ngOnInit() {
    if (this.evento) {
      this.formCadastroEvento.controls.nome.setValue(this.evento.nome);
      this.formCadastroEvento.controls.data.setValue(moment(this.evento.data, 'YYYY-MM-DD HH:mm').toDate());
      this.convidados = this.evento.convidados || [];
      this.convidados.map(convidado => {
        convidado.statusNome = Status[convidado.status];
      })
    }
  }

  salvar($event){
    $event.preventDefault();

    try {
      this.validarInformacoes();
      const _evento = this.formCadastroEvento.value;
      this.evento.convidados = this.convidados;
      this.evento.nome = _evento.nome;
      this.evento.data = _evento.data;
      if (this.evento.id > 0) {
        this.eventoService.alterar(this.evento).subscribe(() => {
          this.toastr.success('Registro atualizado com sucesso.');
          this.bsModalRef.hide();
        })
      } else {
        this.eventoService.inserir(this.evento).subscribe(() => {
          this.toastr.success('Registro inserido com sucesso.');
          this.bsModalRef.hide();
        })
      }
    } catch (error) {
      this.toastr.error(error);
    }
  }

  adicionarConvidado() {
    if (this.formAddConvidado.invalid) {
      this.toastr.error('Informe o nome do convidado corretamente.');
    } else {
      this.convidados.push(new Convidado(this.formAddConvidado.value.nome, Status.PENDENTE));
      this.formAddConvidado.reset();
    }

    console.log(this.convidados);
  }
  validarInformacoes() {
    if (this.formCadastroEvento.controls.nome.invalid) {
      throw 'O campo Nome deve ser preenchido corretamente.';
    }
    
    if (this.formCadastroEvento.controls.data.invalid) {
      throw 'O campo Data deve ser preenchido corretamente.';
    }

    const dataEvento = moment(this.formCadastroEvento.value.data, 'DD/MM/YYYY HH:mm');
    if (!dataEvento.isValid()) {
      throw 'O campo Data está em formato inválido.';
    } else if (dataEvento.isBefore(moment())) {
      throw 'A data do evento dever ser maior que a data atual.';
    }
  }

  confirmar(index: number) {
    this.alterarStatusConvidado(index, Status.CONFIRMADO);
  }
  negar(index: number) {
    this.alterarStatusConvidado(index, Status.NEGADO);
  }
  excluir(index: number) {
    this.convidados.splice(index, 1);
  }

  private alterarStatusConvidado(index: number, status: Status) {
    this.convidados[index].status = status;
    this.convidados[index].statusNome = Status[status];
  }

}
