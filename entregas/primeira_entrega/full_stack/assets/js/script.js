import { data } from "./dados.js";

document.addEventListener("DOMContentLoaded", () => {
  console.log("Página carregada com sucesso!");

  const toggleContentButton = document.getElementById("toggleContentButton");
  const content = document.getElementById("content");

  toggleContentButton.addEventListener("click", () => {
    if (content.style.display === "none") {
      content.style.display = "block";
    } else {
      content.style.display = "none";
    }
  });

  const container = document.getElementById("dynamicContent");
  data.forEach((item) => {
    const div = document.createElement("div");
    div.className = "col-lg-4";
    div.innerHTML = `
      <h2 class="fw-normal">${item.title}</h2>
      <p>${item.description}</p>
      <p><a class="btn btn-secondary" href="#">Ver detalhes &raquo;</a></p>
    `;
    container.appendChild(div);
  });
});
