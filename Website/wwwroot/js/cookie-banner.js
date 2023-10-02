(function () {
    const privacyPolicyUrl =
        window.ehzCookieBanner_privacyPolicyUrl ||
        "https://ehzgames.studio/privacy-policy";
    const localizationData = {
        body: "This website uses cookies. By using this site you agree to the use of cookies, our policies, copyright terms and other conditions. Read our {0}.",
        privacyPolicyLink: '<a href="{0}" target="_blank">Privacy Policy</a>',
        button: "Accept and Close",
        ...window.ehzCookieBanner_localizationData,
    };
    // Get session variable for 'ehzHideCookieBanner'
    if (localStorage.getItem("ehzHideCookieBanner") === "true") {
        return;
    }
    window.addEventListener("load", function () {
        // Put cookie banner
        document.body.appendChild(buildCookieBanner());
    });

    function buildCookieBanner() {
        var banner = document.createElement("div");
        banner.className = "cookie-banner";

        // body
        var cookieBody = document.createElement("p");
        cookieBody.className = "cookie-banner__body";
        cookieBody.innerHTML = localizationData.body.replace(
            "{0}",
            localizationData.privacyPolicyLink.replace("{0}", privacyPolicyUrl)
        );
        banner.appendChild(cookieBody);

        // Accept button
        var acceptButton = document.createElement("button");
        acceptButton.className = "cookie-banner__button button --primary";
        acceptButton.innerText = "Accept and Close";
        acceptButton.addEventListener("click", function () {
            banner.classList.add("--hide");
            localStorage.setItem("ehzHideCookieBanner", "true");
        });
        banner.appendChild(acceptButton);

        // Style
        var style = document.createElement("style");
        style.innerHTML = `
            .cookie-banner {
                color: #FFF;
                background-color: #555;
                position: fixed;
                padding: 0.5rem;
                bottom: 0px;
                left: 0px;
                right: 0px;
                z-index: 9999;
            }

            .cookie-banner.--hide {
                display: none;
            }

            .cookie-banner__body {
                padding: 0.5rem;
                margin: 0px;
            }

            .cookie-banner a {
                color: lightgray;
                text-decoration: underline;
            }

            .cookie-banner a:hover {
                color: white;
            }

            .cookie-banner__button {
                width: 100%;
                padding: 0.8rem;
            }

            .button {
                display: inline-block;
                overflow: hidden;
                padding: 0px;
                margin: 0px;
            }
            
            button.button {
                color: #ffffff;
                display: block;
                font-size: 18px;
                transition: all 250ms ease-out;
                line-height: 1.5;
                cursor: pointer;
                border: 1px solid transparent;
            }
            
            button.button.--primary {
                color: #ffffff;
                background-color: rgba(0, 0, 0, 1);
            }
            
            button.button:focus,
            button.button:hover {
                border: 1px solid;
            }
        `;
        banner.appendChild(style);

        return banner;
    }
})();
