import { PhotoModel } from "./photoModel";

export class UpdateCarModel{
    id: string = '';    
    model: string = '';
    yearOfEdition: number = 0;
    bodyType: number = 0;
    color: number = 0;
    engine: string = "";
    fuelConsumption: number = 0.0;
    price: number = 0.0;
    isAvailable: boolean = false;
    porscheCenterId: number = 0;
    photos: PhotoModel[] | null = [];
}