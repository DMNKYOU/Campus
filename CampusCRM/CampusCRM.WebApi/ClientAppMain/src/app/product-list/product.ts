export interface IProduct {
    _id: string;
    name: string;
    desc: string;
    category: string;
    department: string;
    price: number;
    stock: number;
    reviews: [string];    
    images: [string];
    sizes: [number];    
}