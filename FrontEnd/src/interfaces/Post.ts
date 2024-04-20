export interface Post {
  id: string;
  userName: string;
  createdAt: string;
  updatedAt: string;
  title: string;
  descriptionPost?: string;
  userId: number | null;
}
