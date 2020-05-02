import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CateComponent } from './cate.component';

describe('CateComponent', () => {
  let component: CateComponent;
  let fixture: ComponentFixture<CateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
