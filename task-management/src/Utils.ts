export const formatDate = (date: Date | string): string => {
  let dateString = date.toString();
  return dateString.split("T")[0];
};
