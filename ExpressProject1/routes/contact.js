var express = require('express');
var router = express.Router();
var path = require('path');

/* GET contact page */
router.get('/', function (req, res, next) {
    res.sendFile(path.join(__dirname, '../public/contact.html'));
});

module.exports = router;
