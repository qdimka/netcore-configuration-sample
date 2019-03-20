import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import {OptionsSingletonComponent} from './options-singleton/options-singleton.component';
import {OptionsNamedComponent} from './options-named/options-named.component';
import {OptionsScopedComponent} from './options-scoped/options-scoped.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    FetchDataComponent,
    OptionsSingletonComponent,
    OptionsScopedComponent,
    OptionsNamedComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'singleton', component: OptionsSingletonComponent },
      { path: 'scoped', component: OptionsScopedComponent },
      { path: 'named', component: OptionsNamedComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
