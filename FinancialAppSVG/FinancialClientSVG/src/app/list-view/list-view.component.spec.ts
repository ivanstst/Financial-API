import { ComponentFixture, TestBed } from '@angular/core/testing';
import { SavedViewsComponent } from './list-view.component';

describe('SavedViewsComponent', () => {
  let component: SavedViewsComponent;
  let fixture: ComponentFixture<SavedViewsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SavedViewsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SavedViewsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
