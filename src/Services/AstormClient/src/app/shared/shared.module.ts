import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from './material.module';
import { TranslateModule } from '@ngx-translate/core';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MaterialModule,
  ],
  exports: [
    MaterialModule,
    TranslateModule
  ]
})
export class SharedModule { }
