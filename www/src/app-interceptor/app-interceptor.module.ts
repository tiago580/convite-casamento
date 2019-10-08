import { NgModule, Injectable } from '@angular/core';
import { CommonModule } from '@angular/common';

import {
  HttpEvent,
  HttpInterceptor,
  HttpHandler,
  HttpRequest,
  HttpResponse,
  HttpErrorResponse,
} from '@angular/common/http';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, tap, catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Injectable()

export class HttpsRequestInterceptor implements HttpInterceptor {
  constructor(private toast: ToastrService){

  }
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler,
  ): Observable<HttpEvent<any>> {
    const dupReq = req.clone();
    return next.handle(dupReq).pipe(
      tap(evt => {}),
      catchError(error => {
        const mensagemPadrao = 'Falha na comunicação com o servidor';
        if(error instanceof HttpErrorResponse) {
          try {
            if (typeof(error.error) === 'string') {
              this.toast.error(error.error);
            }else if (error.status === 0){
              this.toast.error(mensagemPadrao);
            }
              
          } catch(e) {
              this.toast.error(mensagemPadrao);
          }
      }
        return of(error);
      })
      );
  }
}

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpsRequestInterceptor,
      multi: true,
    },
  ]
})
export class AppInterceptorModule { }
