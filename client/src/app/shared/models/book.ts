export interface Book {
  id: number;
  isbn: string;
  title: string;
  authorId: number;
  authorFirstName: string;
  authorLastName: string;
  format: string;
  onSaleDate: string;
  publishDate: string;
  imageUrl: string;
}
