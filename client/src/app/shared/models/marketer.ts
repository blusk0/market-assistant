import { MarketerAssignment } from './marketerAssignment';
export interface Marketer {
  id: number;
  employeeId: string;
  firstName: string;
  lastName: string;
  marketerAssignments: MarketerAssignment[];
}
