import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PendingFriendsPresenterComponent } from './pending-friends-presenter.component';

describe('PendingFriendsPresenterComponent', () => {
  let component: PendingFriendsPresenterComponent;
  let fixture: ComponentFixture<PendingFriendsPresenterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PendingFriendsPresenterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PendingFriendsPresenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
