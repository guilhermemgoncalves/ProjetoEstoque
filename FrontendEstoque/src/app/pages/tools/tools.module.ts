import { ToolsRoutingModule } from './tools-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToolsComponent } from './tools.component';
import { HomeRoutingModule } from '../home/home-routing.module';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { AccordionModule } from 'ngx-bootstrap/accordion';


@NgModule({
  declarations: [
    ToolsComponent
  ],
  imports: [
    CommonModule,
    ToolsRoutingModule,
    HomeRoutingModule,
    ButtonsModule.forRoot(),
    AccordionModule.forRoot(),
    ],
  exports:[
    ToolsComponent
  ]
})
export class ToolsModule { }
