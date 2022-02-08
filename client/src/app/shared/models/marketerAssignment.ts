import { Book } from './book';
import { Marketer } from './marketer';

export interface MarketerAssignment {
  id: number;
  marketer?: Marketer;
  book?: Book;
  assignedDt: string;
  unassignedDt?: string;
}
