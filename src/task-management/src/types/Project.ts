export interface Project {
  id: number;
  name: string;
  description: string;
  dueDate: Date | string;
  estimatedStartDate: Date | string;
  estimatedEndDate: Date | string;
  estimatedManHours: number;
}
