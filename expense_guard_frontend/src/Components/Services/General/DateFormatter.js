/* eslint-disable import/prefer-default-export */
export function toGermanFormat(date) {
  const newDate = new Date(date);
  const deFormattedDate = newDate.toLocaleDateString("de-DE", {
    day: "2-digit",
    month: "2-digit",
    year: "numeric",
  });
  return deFormattedDate;
}
