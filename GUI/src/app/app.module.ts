import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
 import { DataTableModule } from 'angular2-datatable';
 import { Http, Headers, Response,XHRBackend, RequestOptions,HttpModule, } from '@angular/http';
 import { HttpClientModule , HttpClient, HTTP_INTERCEPTORS} from '@angular/common/http';
 import { APP_BASE_HREF } from '@angular/common';
//  import { httpFactory } from '././Interceptor/http.factory';
// import { NgSelectModule } from '@ng-select/ng-select';
// import { Ng2DatetimePickerModule } from 'ng2-datetime-picker';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    DataTableModule,
    HttpModule,
    HttpClientModule,

    // NgSelectModule,
    // Ng2DatetimePickerModule
  ],

  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
