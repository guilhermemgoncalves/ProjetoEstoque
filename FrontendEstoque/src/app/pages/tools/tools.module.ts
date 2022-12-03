import { ToolsRoutingModule } from './tools-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToolsComponent } from './tools.component';
import { HomeRoutingModule } from '../home/home-routing.module';



@NgModule({
  declarations: [
    ToolsComponent
  ],
  imports: [
    CommonModule,
    ToolsRoutingModule,
    HomeRoutingModule
  ],
  exports:[
    ToolsComponent
  ]
})
export class ToolsModule { }
