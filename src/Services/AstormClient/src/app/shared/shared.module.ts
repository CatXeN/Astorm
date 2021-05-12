import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from './material.module';
import { TranslateModule } from '@ngx-translate/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MenuCardPresenterComponent } from './menu-card-presenter/menu-card-presenter.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [MenuCardPresenterComponent],
  imports: [
    CommonModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule

  ],
  exports: [
    MaterialModule,
    TranslateModule,
    FormsModule,
    ReactiveFormsModule,
    MenuCardPresenterComponent
  ]
})
export class SharedModule { }
