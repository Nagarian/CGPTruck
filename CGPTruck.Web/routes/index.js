
/*
 * GET home page.
 */

exports.index = function (req, res) {
    res.render('index', { title: ' ', year: new Date().getFullYear() });
};

exports.profile = function (req, res) {
    res.render('profile', { title: 'Profile', year: new Date().getFullYear()});
};

exports.contact = function (req, res) {
    res.render('contact', { title: 'Contact', year: new Date().getFullYear(), message: 'Your contact page' });
};
