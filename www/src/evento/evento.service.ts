import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { CONFIG } from 'src/config';
import { Observable } from 'rxjs';
import { Evento } from './evento';
import { Convidado } from './convidado';

@Injectable({
  providedIn: 'root'
})
export class EventoService {

  constructor(private httpClient: HttpClient) { }

  obter(id: number): Observable<Evento> {
    const url = `${CONFIG.url}/evento/${id}`;
    return this.httpClient.get<Evento>(url);
  }
  filtrarConvidado(id: number, nomeConvidado?: string): Observable<Convidado[]> {
    const url = `${CONFIG.url}/evento/${id}/convidados`;
    let params = new HttpParams();
    if (nomeConvidado) {
      params = params.append('nome', nomeConvidado.trim());
    }
    return this.httpClient.get<Convidado[]>(url, {params});
  }
  excluir(id: number): Observable<Evento> {
    const url = `${CONFIG.url}/evento/${id}`;
    return this.httpClient.delete<Evento>(url);
  }

  inserir(evento: Evento): Observable<Evento> {
    const headers = new HttpHeaders().append('Content-Type', 'application/json');
    const url = `${CONFIG.url}/evento`;
    return this.httpClient.post<Evento>(url, evento, {headers});
  }
  alterar(evento: Evento): Observable<Evento> {
    const headers = new HttpHeaders().append('Content-Type', 'application/json');
    const url = `${CONFIG.url}/evento/${evento.id}`;
    return this.httpClient.put<Evento>(url, evento, {headers});
  }

  listar(nome?: string, dataInicial?: string, dataFinal?: string): Observable<Evento[]> {
    const url = `${CONFIG.url}/evento`;

    let params = new HttpParams();
    if (nome) {
      params = params.append('nome', nome);
    }
    if (dataInicial) {
      params = params.append('dataInicial', dataInicial);
    }
    if (dataFinal) {
      params = params.append('dataFinal', dataFinal);
    }

    return this.httpClient.get<Evento[]>(url, {params});
  }
}
