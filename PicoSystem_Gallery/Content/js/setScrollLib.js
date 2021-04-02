setScrollItem(document.querySelectorAll('.sldItems'), 4000);
function setScrollItem(itm, timelen) {

    if (itm.length > 0) {
        for (var i = 0; i < itm.length; i++) {
            ssi(itm[i], timelen);
        }
    }

    function ssi(items, timelen) {
        var p = items.querySelector('.sld-item');
        if (p != null) {
            var autorun = items.getAttribute("data-animation");
            var style2 = p.currentStyle || window.getComputedStyle(p);
            
            function runInterval() {
                items.marginlen = parseInt(style2.marginRight) + parseInt(style2.marginLeft);
                items.elmlen = parseInt(p.offsetWidth) + items.marginlen;
                items.alllen = parseInt(items.lastElementChild.firstElementChild.offsetWidth);
                items.sldlen = parseInt(items.offsetWidth);
                if (Number.isNaN(items.sldpoint)) {
                    items.sldpoint = 0;
                }
                if (items.sldpoint >= (items.alllen - items.sldlen)) {
                    items.sldpoint = 0;
                } else {


                    if (items.sldpoint < (items.alllen - items.sldlen) - items.elmlen) {
                        items.sldpoint = (items.sldpoint + items.elmlen);
                    } else {
                        items.sldpoint = (items.alllen - items.sldlen) + items.marginlen;
                    }
                }
                items.lastElementChild.firstElementChild.style.right = -items.sldpoint + 'px';
            }
            if (autorun == "true") {
                id = setInterval(runInterval, timelen);
            }
            
            items.querySelector('.sld-arrow-right').addEventListener('click', function (e) {
                items.marginlen = parseInt(style2.marginRight) + parseInt(style2.marginLeft);
                items.elmlen = parseInt(p.offsetWidth) + items.marginlen;
                items.alllen = parseInt(items.lastElementChild.firstElementChild.offsetWidth);
                items.sldlen = parseInt(items.offsetWidth);
                items.sldpoint = Math.abs(parseInt(items.lastElementChild.firstElementChild.style.right));
                e.preventDefault(); e.stopPropagation();
                if (items.sldpoint == 0) {
                    items.sldpoint = (items.alllen - items.sldlen) + items.marginlen;
                } else {
                    if (items.sldpoint > items.elmlen) {
                        items.sldpoint = items.sldpoint - items.elmlen;
                        
                    }
                    else {
                        items.sldpoint = 0;
                    }
                }
                items.lastElementChild.firstElementChild.style.right = -items.sldpoint + 'px';
            });
            items.querySelector('.sld-arrow-left').addEventListener('click', function (e) {
                e.preventDefault(); e.stopPropagation();
                items.marginlen = parseInt(style2.marginRight) + parseInt(style2.marginLeft);
                items.elmlen = parseInt(p.offsetWidth) + items.marginlen;
                items.alllen = parseInt(items.lastElementChild.firstElementChild.offsetWidth);
                items.sldlen = parseInt(items.offsetWidth);
                items.sldpoint = Math.abs(parseInt(items.lastElementChild.firstElementChild.style.right)) || 0;
                if (Number.isNaN(items.sldpoint)) {
                    items.sldpoint = 0;
                }
                if (items.sldpoint >= (items.alllen - items.sldlen)) {
                    items.sldpoint = 0;
                } else {


                    if (items.sldpoint < (items.alllen - items.sldlen) - items.elmlen) {
                        items.sldpoint = (items.sldpoint + items.elmlen);
                    } else {
                        items.sldpoint = (items.alllen - items.sldlen) + items.marginlen;
                    }
                }
                items.lastElementChild.firstElementChild.style.right = -items.sldpoint + 'px';
            });
            items.addEventListener('mouseover', function () {
                if (autorun == "true") {
                    clearInterval(id);
                }

            });
            items.addEventListener('mouseleave', function () {
                if (autorun == "true") {
                    id = setInterval(runInterval, timelen);
                }

            });
        }

    };
};

setScrollGl(document.querySelectorAll('.sld-gl'));
function setScrollGl(itm) {
    if (itm.length > 0) {
        for (var i = 0; i < itm.length; i++) {
            ssgl(itm[i]);
        }
    }

    function ssgl(items) {
        var p = items.querySelector('.sld-item');
        if (p != null) {
            var style2 = p.currentStyle || window.getComputedStyle(p);
            items.marginlen = parseInt(style2.marginRight) + parseInt(style2.marginLeft);
            items.elmlen = parseInt(p.offsetWidth) + items.marginlen;
            items.alllen = parseInt(items.lastElementChild.firstElementChild.offsetWidth);
            items.sldlen = parseInt(items.offsetWidth);
            items.sldpoint = Math.abs(parseInt(items.lastElementChild.firstElementChild.style.right)) || 0;
            items.querySelector('.sld-gl-right').addEventListener('click', function (n) {
                n.preventDefault(), n.stopPropagation();
                if (items.sldpoint == 0) {
                    items.sldpoint = (items.alllen - items.sldlen);
                } else {
                    if (items.sldpoint > items.elmlen) {
                        items.sldpoint = items.sldpoint - items.elmlen;
                    }
                    else {
                        items.sldpoint = 0;
                    }
                }
                items.lastElementChild.firstElementChild.style.right = -items.sldpoint + 'px';
            });
            items.querySelector('.sld-gl-left').addEventListener('click', function (n) {
                n.preventDefault(), n.stopPropagation();
                if (Number.isNaN(items.sldpoint)) {
                    items.sldpoint = 0;
                }
                if (items.sldpoint >= (items.alllen - items.sldlen)) {
                    items.sldpoint = 0;
                } else {


                    if (items.sldpoint < (items.alllen - items.sldlen) - items.elmlen) {
                        items.sldpoint = (items.sldpoint + items.elmlen);
                    } else {
                        items.sldpoint = (items.alllen - items.sldlen);
                    }
                }
                items.lastElementChild.firstElementChild.style.right = -items.sldpoint + 'px';
            });
            //items.querySelector('.sld-gl').addEventListener('mouse', function () {

            //});
        }

    };
};


