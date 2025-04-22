const express = require("express");
const router = express.Router();
const userController = require("../controllers/user.controller");
const verifyToken = require("../middlewares/auth.middleware");

router.get("/", verifyToken, userController.getUsers);
router.post("/", verifyToken, userController.createUser);

module.exports = router;
