import { Component } from '@angular/core';
import { PorscheCenterCreateModel } from '../../../../models/porscheCenterCreateModel';
import { PorscheCenterService } from '../../../../services/PorscheCenterService';
import { PorscheCenterUpdateModel } from '../../../../models/porscheCenterUpdateModel';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-update-center',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './update-center.component.html',
  styleUrl: './update-center.component.scss'
})
export class UpdateCenterComponent {

  constructor(private porscheCenterService: PorscheCenterService,
    private router: ActivatedRoute,
  ){
    this.router.paramMap.subscribe((params) => {
    let id = params.get('id');
      if (id != null)
        porscheCenterService.getById(id).subscribe(data => {
          this.porscheCenterUpdateModel = data
        });
    })
  }
  porscheCenterUpdateModel = new PorscheCenterUpdateModel();
  message: string = '';

  onFileChange(event: any) {
    this.porscheCenterUpdateModel.photo = event.target.files[0];
  }

  onUpdate() {
    let formData = new FormData();
    formData.append("Id", this.porscheCenterUpdateModel.id);
    formData.append("Name", this.porscheCenterUpdateModel.name);
    formData.append("Address", this.porscheCenterUpdateModel.address);
    if (this.porscheCenterUpdateModel.photo)
      formData.append("PhotoPath", this.porscheCenterUpdateModel.photo);

    this.porscheCenterService.update(formData).subscribe(() => {
      this.message = "Updated";
    },
      errorResponse => this.message = errorResponse)
  }
}
