import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModelsRowComponent } from './models-row.component';

describe('ModelsRowComponent', () => {
  let component: ModelsRowComponent;
  let fixture: ComponentFixture<ModelsRowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ModelsRowComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ModelsRowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
