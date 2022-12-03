import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import {MatMenuModule} from '@angular/material/menu';

import { HeaderComponent } from './header.component';
import {  MatButtonModule} from '@angular/material/button';
import { HomeRoutingModule } from 'src/app/pages/home/home-routing.module';


@NgModule({
  declarations: [
    HeaderComponent
  ],
  imports: [
    CommonModule,
    MatToolbarModule,
    MatIconModule,
    MatMenuModule,
    MatButtonModule,
    HomeRoutingModule,
    MatMenuModule
  ],
  exports:[
    HeaderComponent
  ]
})
export class HeaderModule { }
