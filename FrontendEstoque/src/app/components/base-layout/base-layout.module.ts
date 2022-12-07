import { RouterModule } from '@angular/router';
import { SidenavModule } from './../sidenav/sidenav.module';
import { FooterModule } from './../footer/footer.module';

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BaseLayoutComponent } from './base-layout.component';
import { HeaderModule } from '../header/header.module';


@NgModule({
  declarations: [BaseLayoutComponent],
  imports: [
    CommonModule,
    HeaderModule,
    FooterModule,
    SidenavModule,
    RouterModule],

    exports: [BaseLayoutComponent],
})
export class BaseLayoutModule {}
