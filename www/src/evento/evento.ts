import { Convidado } from './convidado';

export class Evento {
    public id: number;
    public nome: string;
    public data: Date = new Date();
    public convidados: Convidado[];

}
