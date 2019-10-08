import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';


import { ModalModule } from 'ngx-bootstrap/modal';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { ToastrModule } from 'ngx-toastr';

import { defineLocale } from 'ngx-bootstrap/chronos';
import { ptBrLocale } from 'ngx-bootstrap/locale';
defineLocale('pt-br', ptBrLocale);


import { AppComponent } from './app.component';
import { EventoCadastroComponent } from './evento-cadastro/evento-cadastro.component';
import { AppInterceptorModule } from 'src/app-interceptor/app-interceptor.module';


@NgModule({
  declarations: [
    AppComponent,
    EventoCadastroComponent
  ],
  imports: [
    ReactiveFormsModule,
    BrowserModule,
    BrowserAnimationsModule,
    ModalModule.forRoot(),
    BsDatepickerModule.forRoot(),
    ToastrModule.forRoot(),
    HttpClientModule,
    AppInterceptorModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  entryComponents: [EventoCadastroComponent]
})
export class AppModule { }
