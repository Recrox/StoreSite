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

  imgUrl =
    'https://cdn-elle.ladmedia.fr/var/plain_site/storage/images/elle-a-table/fiches-cuisine/tous-les-themes/recettes-de-desserts-au-chocolat/88701296-2-fre-FR/Recettes-de-desserts-au-chocolat.jpg';
}
