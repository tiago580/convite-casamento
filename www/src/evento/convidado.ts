import { Status } from './status';

export class Convidado {
    public id: number;
    public nome: string;
    public status: Status;
    private _statusNome: string;

    constructor(nome?: string, status?: Status) {
        this.nome = nome;
        this.status = status;
    }


    public get statusNome() {
        if (!this._statusNome) {
            this._statusNome = Status[this.status];
        }
        return this._statusNome;
    }

    public set statusNome(value: string) {
        this._statusNome = value;
    }
}
