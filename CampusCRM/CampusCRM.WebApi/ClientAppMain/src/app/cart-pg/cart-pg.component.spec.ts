import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CartPgComponent } from './cart-pg.component';

describe('CartPgComponent', () => {
  let component: CartPgComponent;
  let fixture: ComponentFixture<CartPgComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CartPgComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CartPgComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
