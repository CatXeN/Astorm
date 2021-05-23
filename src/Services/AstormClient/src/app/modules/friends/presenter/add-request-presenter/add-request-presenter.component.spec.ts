import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddRequestPresenterComponent } from './add-request-presenter.component';

describe('AddRequestPresenterComponent', () => {
  let component: AddRequestPresenterComponent;
  let fixture: ComponentFixture<AddRequestPresenterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddRequestPresenterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddRequestPresenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
