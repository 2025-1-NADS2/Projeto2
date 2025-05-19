const { Sequelize } = require("sequelize");

const sequelize = new Sequelize("instituto_criativo_db", "root", "sua_senha", {
  host: "localhost",
  dialect: "mysql",
  logging: false, // Desabilita logs SQL no console
});

module.exports = sequelize;
