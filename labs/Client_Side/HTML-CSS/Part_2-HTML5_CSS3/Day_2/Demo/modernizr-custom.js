/*! modernizr 3.6.0 (Custom Build) | MIT *
 * https://modernizr.com/download/?-input-inputtypes-setclasses !*/
!function(e,t,n){function a(e){var t=c.className,n=Modernizr._config.classPrefix||"";if(f&&(t=t.baseVal),Modernizr._config.enableJSClass){var a=new RegExp("(^|\\s)"+n+"no-js(\\s|$)");t=t.replace(a,"$1"+n+"js$2")}Modernizr._config.enableClasses&&(t+=" "+n+e.join(" "+n),f?c.className.baseVal=t:c.className=t)}function s(){return"function"!=typeof t.createElement?t.createElement(arguments[0]):f?t.createElementNS.call(t,"http://www.w3.org/2000/svg",arguments[0]):t.createElement.apply(t,arguments)}function i(e,t){return typeof e===t}function o(){var e,t,n,a,s,o,u;for(var c in r)if(r.hasOwnProperty(c)){if(e=[],t=r[c],t.name&&(e.push(t.name.toLowerCase()),t.options&&t.options.aliases&&t.options.aliases.length))for(n=0;n<t.options.aliases.length;n++)e.push(t.options.aliases[n].toLowerCase());for(a=i(t.fn,"function")?t.fn():t.fn,s=0;s<e.length;s++)o=e[s],u=o.split("."),1===u.length?Modernizr[u[0]]=a:(!Modernizr[u[0]]||Modernizr[u[0]]instanceof Boolean||(Modernizr[u[0]]=new Boolean(Modernizr[u[0]])),Modernizr[u[0]][u[1]]=a),l.push((a?"":"no-")+u.join("-"))}}var l=[],r=[],u={_version:"3.6.0",_config:{classPrefix:"",enableClasses:!0,enableJSClass:!0,usePrefixes:!0},_q:[],on:function(e,t){var n=this;setTimeout(function(){t(n[e])},0)},addTest:function(e,t,n){r.push({name:e,fn:t,options:n})},addAsyncTest:function(e){r.push({name:null,fn:e})}},Modernizr=function(){};Modernizr.prototype=u,Modernizr=new Modernizr;var c=t.documentElement,f="svg"===c.nodeName.toLowerCase(),p=s("input"),m="search tel url email datetime date month week time datetime-local number range color".split(" "),d={};Modernizr.inputtypes=function(e){for(var a,s,i,o=e.length,l="1)",r=0;o>r;r++)p.setAttribute("type",a=e[r]),i="text"!==p.type&&"style"in p,i&&(p.value=l,p.style.cssText="position:absolute;visibility:hidden;",/^range$/.test(a)&&p.style.WebkitAppearance!==n?(c.appendChild(p),s=t.defaultView,i=s.getComputedStyle&&"textfield"!==s.getComputedStyle(p,null).WebkitAppearance&&0!==p.offsetHeight,c.removeChild(p)):/^(search|tel)$/.test(a)||(i=/^(url|email)$/.test(a)?p.checkValidity&&p.checkValidity()===!1:p.value!=l)),d[e[r]]=!!i;return d}(m);var h="autocomplete autofocus list placeholder max min multiple pattern required step".split(" "),g={};Modernizr.input=function(t){for(var n=0,a=t.length;a>n;n++)g[t[n]]=!!(t[n]in p);return g.list&&(g.list=!(!s("datalist")||!e.HTMLDataListElement)),g}(h),o(),a(l),delete u.addTest,delete u.addAsyncTest;for(var v=0;v<Modernizr._q.length;v++)Modernizr._q[v]();e.Modernizr=Modernizr}(window,document);