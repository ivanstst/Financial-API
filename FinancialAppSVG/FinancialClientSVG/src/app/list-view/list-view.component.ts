import { Component, inject } from '@angular/core';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { Router } from '@angular/router';
import { ViewService } from '../services/views.service';

@Component({
  selector: 'app-list-view',
  standalone: true,
  imports: [
    TableModule,
    ButtonModule
  ],
  templateUrl: './list-view.component.html',
  styleUrl: './list-view.component.scss'
})

export class SavedViewsComponent {
  constructor(router: Router) {
    this.router = router;
  }

  private router: Router;
  savedViews: any = { data: [] };
  private viewService = inject(ViewService);

  ngOnInit() {
    this.savedViews = this.viewService.getSavedViews();
  }
  goBack() {
    this.router.navigate(['/chart']);
  }

  viewSavedView(view: any) {
    this.router.navigate(['/chart'],
      { queryParams: { viewId: view.id } });
  }

  deleteSavedView(view: any) {

  }
}

