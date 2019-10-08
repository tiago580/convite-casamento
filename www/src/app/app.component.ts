import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { EventoCadastroComponent } from './evento-cadastro/evento-cadastro.component';
import { EventoService } from 'src/evento/evento.service';
import { Evento } from 'src/evento/evento';
import { Subscription } from 'rxjs';
import { FormGroup, FormControl } from '@angular/forms';
import * as moment from 'moment';
import { ToastrService } from 'ngx-toastr';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'Convite de Casamento';
  idExclusao: number;
  frmFiltro = new FormGroup({
    nome: new FormControl(''),
    dataInicial: new FormControl(new Date()),
    dataFinal: new FormControl('')
  });
  eventos: Evento[] = [];
  bsModalRef: BsModalRef;
  subscription: Subscription;
  constructor(
    private modalService: BsModalService,
    private toastr: ToastrService,
    private eventoService: EventoService,
    private localeService: BsLocaleService
    ) {

      this.localeService.use('pt-br');
    }
  ngOnInit() {

    this.filtrar();
  }

  filtrar(){
    const dtFormat = 'YYYY-MM-DD HH:mm';
    const filtro = this.frmFiltro.value;
    if (filtro.dataInicial) {
      filtro.dataInicial = moment(filtro.dataInicial, dtFormat).format();
    }

    if (filtro.dataFinal) {
      filtro.dataFinal = moment(filtro.dataFinal, dtFormat).format();
    }
    this.eventoService.listar(filtro.nome, filtro.dataInicial, filtro.dataFinal).subscribe(eventos => {
      this.eventos = eventos;
    });

  }

  openModalWithComponent(title?: string, evento?: Evento) {
    const initialState = {
      title: title || 'Novo Evento',
      evento: evento || new Evento()
    };
    this.bsModalRef = this.modalService.show(EventoCadastroComponent, {initialState, keyboard: false, ignoreBackdropClick: true, class: 'modal-lg'});
    this.subscription = this.modalService.onHide.subscribe(() => {
      this.subscription.unsubscribe();
      this.filtrar();
    })
  }

  editar(id: number) {
    this.eventoService.obter(id).subscribe(result => {
      this.openModalWithComponent('Editar Evento', result);
    })
  }
  excluir(id: number, template: TemplateRef<any>) {
    this.idExclusao = id;
    this.bsModalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirmarExclusao() {
    this.eventoService.excluir(this.idExclusao).subscribe(() => {
      this.bsModalRef.hide();
      this.toastr.success('Registro removido com sucesso.');
      this.idExclusao = null;
      this.filtrar();
    })
  }

}
