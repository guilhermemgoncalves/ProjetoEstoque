import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CostumersRoutingModule } from './costumers-routing.module';
import { CostumersComponent } from './costumers.component';


@NgModule({
  declarations: [
    CostumersComponent
  ],
  imports: [
    CommonModule,
    CostumersRoutingModule
  ],
  exports: [
    CostumersComponent
  ]
})
export class CostumersModule { }
