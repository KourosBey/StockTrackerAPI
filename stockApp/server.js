// const jsonServer = require("json-server");
// const server = jsonServer.create();
// const router = jsonServer.router("db.json");
// const middlewares = jsonServer.defaults();

// server.use(middlewares);
// server.use(jsonServer.bodyParser);

// // Nested data için özel POST işlemi
// server.post("/stocks/0/data", (req, res) => {
//     const db = router.db; // lowdb instance
//     const newStock = req.body;
//     db.get("stocks[0].data").push(newStock).write(); // Yeni veriyi ekle
//     res.status(201).json(newStock);
// });

// server.use(router);

// server.listen(3002, () => {
//     console.log("JSON Server is running on http://localhost:3002");
// });
