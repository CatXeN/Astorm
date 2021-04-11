import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OperationCardPresenterComponent } from './operation-card-presenter.component';

describe('OperationCardPresenterComponent', () => {
  let component: OperationCardPresenterComponent;
  let fixture: ComponentFixture<OperationCardPresenterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OperationCardPresenterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OperationCardPresenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
