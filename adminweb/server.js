const express = require('express');
const multer = require('multer');
const path = require('path');
const fs = require('fs');

const app = express();
const port = 3000;
var toCopy = "";

// Multer configuration for storing uploaded files
const storage = multer.diskStorage({
  destination: function (req, file, cb) {
    cb(null, 'uploads/');
  },
  filename: function (req, file, cb) {
    console.log(req.body.filename);
    toCopy = req.body.filename + path.extname(file.originalname);
    cb(null,  req.body.filename + path.extname(file.originalname));
  }
});

const upload = multer({ storage: storage });

app.use(express.static('public'));

app.post('/upload', upload.single('image'), (req, res) => {
  if (!req.file) {
    return res.status(400).send('No files were uploaded.');
  }
  res.send('File uploaded successfully!');
  fs.copyFile('uploads/'+toCopy, 'C:/Users/Vaishanvi/Desktop/Siddhesh/SEM IV/Projects/.NET/dontnetmicroserv/webdemo/Images/'+toCopy, (err) => {
    if (err) throw err;
    console.log('source.txt was copied to destination.txt');
  });
});

app.listen(port, () => {
  console.log(`Server listening at http://localhost:${port}`);
});