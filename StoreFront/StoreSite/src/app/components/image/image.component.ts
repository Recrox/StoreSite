import { Component } from '@angular/core';

@Component({
  selector: 'app-image',
  templateUrl: './image.component.html',
  styleUrls: ['./image.component.scss'],
})
export class ImageComponent {
  // this.http:any;
  // getImage() {
  //   this.http.get('http://localhost:5000/api/getimage', { responseType: 'blob' })
  //     .subscribe((response: Blob) => {
  //       const reader = new FileReader();
  //       reader.onloadend = () => {
  //         this.imageSrc = reader.result.toString();
  //       };
  //       reader.readAsDataURL(response);
  //     });
  // }
}
