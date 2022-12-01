import { ToolsRoutingModule } from './tools-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToolsComponent } from './tools.component';



@NgModule({
  declarations: [
    ToolsComponent
  ],
  imports: [
    CommonModule,
    ToolsRoutingModule
  ],
  exports:[
    ToolsComponent
  ]
})
export class ToolsModule { }
