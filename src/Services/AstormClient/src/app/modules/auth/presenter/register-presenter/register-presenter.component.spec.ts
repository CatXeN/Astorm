import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterPresenterComponent } from './register-presenter.component';

describe('RegisterPresenterComponent', () => {
  let component: RegisterPresenterComponent;
  let fixture: ComponentFixture<RegisterPresenterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegisterPresenterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterPresenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
