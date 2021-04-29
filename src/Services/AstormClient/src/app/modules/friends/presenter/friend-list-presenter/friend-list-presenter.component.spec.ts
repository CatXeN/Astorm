import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FriendListPresenterComponent } from './friend-list-presenter.component';

describe('FriendListPresenterComponent', () => {
  let component: FriendListPresenterComponent;
  let fixture: ComponentFixture<FriendListPresenterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FriendListPresenterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FriendListPresenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
