@Imports paymentmanagermodels

@Modeltype HawaiiDiscountHomeIndexViewModel

@Code
    'Model.Title = "Aloha Kai Luau Official Site – Hawaii’s Best Luau at Sea Life Park"
    'Model.MetaDescription = "Aloha Kai Luau Official Site offers the best authentic luau in Oahu Hawaii overlooking the Ocean featuring an award-winning production."
    'Model.MetaKeywords = "Aloha Kai Luau, Aloha Kai Luau Official Site, Sea Life Park Luau, Tickets to Aloha Kai Luau, Best Oahu Luau, Hawaii Luau"
    'Model.Canonical = "https://www.alohakailuau.com"


    Dim oAdult As Price = Model.Activities.First.Prices.Where(Function(pp) pp.Active = True And (pp.Category IsNot Nothing AndAlso pp.Category.Shortcode = "Adult")).OrderBy(Function(p) p.ListPrice).First
    Dim oYouth As Price = Model.Activities.First.Prices.Where(Function(pp) pp.Active = True And (pp.Category IsNot Nothing AndAlso pp.Category.Shortcode = "Youth")).OrderBy(Function(p) p.ListPrice).First
    Dim oChild As Price = Model.Activities.First.Prices.Where(Function(pp) pp.Active = True And (pp.Category IsNot Nothing AndAlso pp.Category.Shortcode = "Child")).OrderBy(Function(p) p.ListPrice).First
    Dim oGoldAdult As Price
    Try
        oGoldAdult = Model.Activities.First.Prices.First(Function(pp) pp.Active = True And (pp.Category IsNot Nothing AndAlso pp.Category.Shortcode = "Adult" AndAlso pp.Groupings.Count > 0 AndAlso pp.Groupings(0).Name = "Gold Package"))
    Catch ex As Exception
        Throw New ApplicationException("Price where Package='Gold Package' Category='Adult' not found.")
    End Try
    Dim oSilverAdult As Price
    Try
        oSilverAdult = Model.Activities.First.Prices.First(Function(pp) pp.Active = True And (pp.Category IsNot Nothing AndAlso pp.Category.Shortcode = "Adult" AndAlso pp.Groupings.Count > 0 AndAlso pp.Groupings(0).Name = "Silver Package"))
    Catch ex As Exception
        Throw New ApplicationException("Price where Package='Silver Package' Category='Adult' not found.")
    End Try
    Dim oBronzeAdult As Price
    Try
        oBronzeAdult = Model.Activities.First.Prices.First(Function(pp) pp.Active = True And (pp.Category IsNot Nothing AndAlso pp.Category.Shortcode = "Adult" AndAlso pp.Groupings.Count > 0 AndAlso pp.Groupings(0).Name = "Bronze Package"))
    Catch ex As Exception
        Throw New ApplicationException("Price where Package='Bronze Package' Category='Adult' not found.")
    End Try

End Code
@Layout Layout.vbhtml
<!-- Body -->
<div class="HomeBody">
    <div class="HomeContentTopBG">
        <div style="height:16px;"></div>
        <div class="content-slider-wrapper" id="hero-slider">
            <a href="tel:+18665245828" id="callin-desktop"><p>Call-in Special<span>25% off</span>All Through<br>November</p></a>

            <!--<a href="tel:+18665245828" id="callin-military" style="background-image: url('/designs/alohakailuau/images/starring.png');"><p><span>local &<br/>military<br/>discounts</span>call now!</p></a>-->
            
	<div class="content-slider">
                <div class="slide">
                    <div class="HomeHeaderImgTwo">
                        <div class="HomeHeaderCotentContainer">
                            <span id="WhiteMed">Aloha Kai Luau</span><br />
                            <h1 id="YellowBig">Official Sea Life Park Luau Site</h1>
                            <br /><br />
                            <span id="GrenSmall">The #1 Luau on Oahu</span> <br /><br /><br /><br /><span id="GrenSmall">Adult: $@math.floor(oAdult.ListPrice) | Youth: $@math.floor(oYouth.ListPrice) | Child: $@math.floor(oChild.ListPrice)</span><br /> 
                            <br /><br />
                            <span style="color: white;font-family: kon-tiki-aloha-jf, sans-serif;text-shadow: 0px 0px 1em black;display: inline-block;text-transform: capitalize !important;font-size: 1.25em;backround-color: rgba(0,0,0,0.75);margin: 0 auto;padding: 0.25em 0.75em;"></span>
                            <br />
                            <a href="https://fareharbor.com/embeds/book/alohakailuau/?asn=hawaiidiscount&asn-ref=alohakailuau.com&full-items=yes&flow=1028780" style="text-decoration: none !important"><div class="HomeHeadButton">BOOK DIRECT</div></a>
                        </div>
                    </div>
                </div>
                <div class="slide">
                    <div class="HomeHeaderImg">
                        <div class="HomeHeaderCotentContainer">
                            <span id="WhiteMed">Aloha Kai Luau</span><br />
                            <h1 id="YellowBig">Official Sea Life Park Luau Site</h1>
                            <br /><br />
                            <span id="GrenSmall">The #1 Luau on Oahu</span> <br /><br /><br /><br /><span id="GrenSmall">Adult: $@math.floor(oAdult.ListPrice) | Youth: $@math.floor(oYouth.ListPrice) | Child: $@math.floor(oChild.ListPrice)</span><br />
                            <br /><br />
                            <span style="color: white;font-family: kon-tiki-aloha-jf, sans-serif;text-shadow: 0px 0px 1em black;display: inline-block;text-transform: capitalize !important;font-size: 1.25em;backround-color: rgba(0,0,0,0.75);margin: 0 auto;padding: 0.25em 0.75em;"></span>
                            <br />
                            <a href="https://fareharbor.com/embeds/book/alohakailuau/?asn=hawaiidiscount&asn-ref=alohakailuau.com&full-items=yes&flow=1028780" style="text-decoration: none !important"><div class="HomeHeadButton">BOOK DIRECT</div></a>
                        </div>
                    </div>
                </div>
                <div class="slide">
                    <div class="HomeHeaderImgThree">
                        <div class="HomeHeaderCotentContainer">
                            <span id="WhiteMed">Aloha Kai Luau</span><br />
                            <h1 id="YellowBig">Official Sea Life Park Luau Site</h1>
                            <br /><br />
                            <span id="GrenSmall">The #1 Luau on Oahu</span> <br /><br /><br /><br /><span id="GrenSmall">Adult: $@math.floor(oAdult.ListPrice) | Youth: $@math.floor(oYouth.ListPrice) | Child: $@math.floor(oChild.ListPrice)</span><br />
                            <br /><br />
                            <span style="color: white;font-family: kon-tiki-aloha-jf, sans-serif;text-shadow: 0px 0px 1em black;display: inline-block;text-transform: capitalize !important;font-size: 1.25em;backround-color: rgba(0,0,0,0.75);margin: 0 auto;padding: 0.25em 0.75em;"></span>
                            <br />
                            <a href="https://fareharbor.com/embeds/book/alohakailuau/?asn=hawaiidiscount&asn-ref=alohakailuau.com&full-items=yes&flow=1028780" style="text-decoration: none !important"><div class="HomeHeadButton">BOOK DIRECT</div></a>
                        </div>
                    </div>
                </div>
                <div class="slide">
                    <div class="HomeHeaderImgFour">
                        <div class="HomeHeaderCotentContainer">
                            <span id="WhiteMed">Aloha Kai Luau</span><br />
                            <h1 id="YellowBig">Official Sea Life Park Luau Site</h1>
                            <br /><br />
                            <span id="GrenSmall">The #1 Luau on Oahu</span> <br /><br /><br /><br /><span id="GrenSmall">Adult: $@math.floor(oAdult.ListPrice) | Youth: $@math.floor(oYouth.ListPrice) | Child: $@math.floor(oChild.ListPrice)</span><br />
                            <br /><br />
                            <span style="color: white;font-family: kon-tiki-aloha-jf, sans-serif;text-shadow: 0px 0px 1em black;display: inline-block;text-transform: capitalize !important;font-size: 1.25em;backround-color: rgba(0,0,0,0.75);margin: 0 auto;padding: 0.25em 0.75em;"></span>
                            <br />
                            <a href="https://fareharbor.com/embeds/book/alohakailuau/?asn=hawaiidiscount&asn-ref=alohakailuau.com&full-items=yes&flow=1028780" style="text-decoration: none !important"><div class="HomeHeadButton">BOOK DIRECT</div></a>
                        </div>
                    </div>
                </div>
                <div class="slide">
                    <div class="HomeHeaderImgFive">
                        <div class="HomeHeaderCotentContainer">
                            <span id="WhiteMed">Aloha Kai Luau</span><br />
                            <h1 id="YellowBig">Official Sea Life Park Luau Site</h1>
                            <br /><br />
                            <span id="GrenSmall">The #1 Luau on Oahu</span>!<br /><br /><br /><br /><span id="GrenSmall">Adult: $@math.floor(oAdult.ListPrice) | Youth: $@math.floor(oYouth.ListPrice) | Child: $@math.floor(oChild.ListPrice)</span><br />
                            <br /><br />
                            <span style="color: white;font-family: kon-tiki-aloha-jf, sans-serif;text-shadow: 0px 0px 1em black;display: inline-block;text-transform: capitalize !important;font-size: 1.25em;backround-color: rgba(0,0,0,0.75);margin: 0 auto;padding: 0.25em 0.75em;"></span>
                            <br />
                            <br /><a href="https://fareharbor.com/embeds/book/alohakailuau/?asn=hawaiidiscount&asn-ref=alohakailuau.com&full-items=yes&flow=1028780" style="text-decoration: none !important"><div class="HomeHeadButton">BOOK DIRECT</div></a>
                        </div>
                    </div>
                </div>
                <div class="slide">
                    <div class="HomeHeaderImgSix">
                        <div class="HomeHeaderCotentContainer">
                            <span id="WhiteMed">THE OFFICIAL SITE</span><br />
                            <h1 id="YellowBig">Official Sea Life Park Luau Site</h1>
                            <br /><br />
                            <span id="GrenSmall">The #1 Luau on Oahu</span> <br /><br /><br /><br /><span id="GrenSmall">Adult: $@math.floor(oAdult.ListPrice) | Youth: $@math.floor(oYouth.ListPrice) | Child: $@math.floor(oChild.ListPrice)</span><br />
                            <br /><br />
                            <span style="color: white;font-family: kon-tiki-aloha-jf, sans-serif;text-shadow: 0px 0px 1em black;display: inline-block;text-transform: capitalize !important;font-size: 1.25em;backround-color: rgba(0,0,0,0.75);margin: 0 auto;padding: 0.25em 0.75em;"></span>
                            <br />
                            <a href="https://fareharbor.com/embeds/book/alohakailuau/?asn=hawaiidiscount&asn-ref=alohakailuau.com&full-items=yes&flow=1028780" style="text-decoration: none !important"><div class="HomeHeadButton">BOOK DIRECT</div></a>
                        </div>
                    </div>
                </div>
            </div>
         
        </div>
        <!--<div id="mobile-callin" style="background-image: url('/designs/alohakailuau/images/military-local-bg.jpeg');">
            <a href="tel:+18665245828" style="background-image: url('/designs/alohakailuau/images/starring.png');"><p><span>local &<br/>military<br/>discounts</span>call now!</p></a>
        </div>-->

		<a href="/promotions.htm" class="gold-anchor">More Discounts & Promotions</a>
		<br>

        <div class="HeaderVideoLeft">
            <!-- lazy load youtube video -->

            <div id="youtube" class="youtube">
            </div>

                <script type="text/javascript">
                    var video = document.getElementById("youtube");
                    var source = "/designs/alohakailuau/images/yt-thumbnail.png";
                    var _alt = "Experience Aloha Kai Luau at Sea Life Park";
                    var image = new Image();
                    image.src = source;
                    image.setAttribute("id", "video-trigger");
                    image.setAttribute("alt", _alt);
                    image.addEventListener("load", function () {
                        video.appendChild(image);
                    }
                    );
                    video.addEventListener("click", function () {
                        var iframe = document.createElement("iframe");
                        iframe.setAttribute("frameborder", "0");
                        iframe.setAttribute("allowfullscreen", "");
                        iframe.setAttribute("src", "https://www.youtube.com/embed/dRqHOmo9L-8?autoplay=1&rel=0&mute=1");  //youtube video source//
                        this.innerHTML = "";
                        this.appendChild(iframe);
                    });
                </script>
        </div>
            <script>
            try {
                window.addEventListener('load', function () {
                    var videoTrigger = document.getElementById('video-trigger'); 
                    var videoTriggerEvent = new MouseEvent('click', {
                        bubbles: true,
                        cancelable: true,
                        view: window
                    });
                        videoTrigger.dispatchEvent(videoTriggerEvent);
                    });
                } catch (error) {
                    console.log(error);
            }
    </script>
        <div class="HeaderExpContent">
            <h3>Experience <span style="color:#6e4836">ALOHA KAI</span></h3>
			<span id="HomeWhysTitles" style="color:#c82b2b"></span>
          <p>Aloha Kai Luau Official Site offers the best authentic luau on Oahu, overlooking the ocean and Rabbit island, featuring an award-winning production. Witness world-class entertainment at Sea Life Park Luau, the best luau on Oahu, that begins and ends with fire!</p>
            <img src="~/designs/alohakailuau/images/ReviewIcons.gif" style="mix-blend-mode: darken;" alt="Review Icons"> 
        </div>
    </div>
    <div class="HomeContentBottomBG"> </div>

    <div class="HomeBottomPageContainer">

        <h2>Luau PACKAGES &amp; Add-Ons</h2>
        <p style="font-size:13pt;">At Aloha Kai Luau we offer 3 options for our Luau seating and upgrades.</p>
        <div class="HomePackageCelebrity">
            <div class="AKCelebTitle">ALOHA KAI GOLD</div>
            <div class="PackageContentCont" style="color: #b6a722;">
                <strong>
                    Flower Lei Greeting<br>
                    Two (2) Drink Tickets<br>
                    Hawaii Welcome Mai Tai<br>
                    Souvenir Photograph<br>
                    GOLD Seating
                </strong><br>
                Cultural Activities<br>
                Buffet Dinner &amp; Live Music<br>
                <strong>10-Day</strong> Pass: Sea Life Park
            </div>
            <div class="AKCelebPrice">$@oGoldAdult.ListPrice</div>
            <a href="https://fareharbor.com/embeds/book/alohakailuau/items/489232/?asn=hawaiidiscount&asn-ref=alohakailuau.com&flow=1028780"><div class="AKCelebButton">Book Direct</div></a>
        </div>

        <div class="HomePackageSplash">
            <div class="AKSTitle">ALOHA KAI SILVER</div>
            <div class="PackageContentCont" style="color: #414141;">
                <strong>
                    Flower Lei Greeting<br>
                    Two (2) Drink Tickets<br>
                    Silver Seating
                </strong><br>
                Cultural Activities<br>
                Buffet Dinner &amp; Live Music<br>
                <strong>5-Day</strong> Pass: Sea Life Park
            </div>
            <div class="AKSPrice">$@oSilverAdult.ListPrice</div>
            <a href="https://fareharbor.com/embeds/book/alohakailuau/items/489387/?asn=hawaiidiscount&asn-ref=alohakailuau.com&flow=1028780"><div class="AKSButton">Book Direct</div></a>
        </div>
        <div class="HomePackageClassic" style="margin-bottom:35px;">
            <div class="AKCTitle">ALOHA KAI BRONZE</div>
            <div class="PackageContentCont" style="color: #764524;">
                Shell Lei Greeting<br>
                One (1) Drink Tickets<br>
                Bronze Seating<br>
                Cultural Activities<br>
                Buffet Dinner &amp; Live Music<br>
                Award Winning Show<br>
				<strong>1-Day</strong> Pass: Sea Life Park
            </div>
            <div class="AKCPrice">$@oBronzeAdult.ListPrice</div>
            <a href="https://fareharbor.com/embeds/book/alohakailuau/items/489391/?asn=hawaiidiscount&asn-ref=alohakailuau.com&flow=1028780"><div class="AKCButton">Book Direct</div></a>
        </div>

        <br><br>
        <h3>LUAU SEATING CHART</h3>
        <p style="font-size:13pt;">Seating chart represents Luau Packages.</p>
        <center><img src="~/designs/alohakailuau/images/SeatingChart.png" style="width:100%;max-width:650px" alt="Seating Chart"></center>
        <h3>TRANSPORTATION AVAILABLE</h3>

        <p style="font-size:13pt; max-width:540px;">We are offering EARLY transportation for guests who wish to redeem their included admission to Sea Life Park the same day as their Lūau. To book, select one of our "EARLY Transportation" options from the booking calendar.</p>
        <center><a href="#"><img src="~/designs/alohakailuau/images/Trans.png" alt="Waikiki Transportation to Sea Life Park"></a></center>

        <h2>WHY BOOK WITH US?</h2>

        <div class="HomeWhys" style="margin-bottom: 17px !important;">
            <img src="~/designs/alohakailuau/images/ThumbsUp.png" alt="No Hassle Reservations"><br>
            <span id="HomeWhysTitles">NO HASSLE RESERVATIONS</span>
            <p style="font-size:12pt;">If something happens and you are not able to make it, we are here to help you. Cancellations of 48 hours or more in advance are fully refundable.</p>
        </div>
        <div class="HomeWhys">
            <img src="~/designs/alohakailuau/images/DollarSIgn.png" alt="Best Price Guarantee"><br>
            <span id="HomeWhysTitles">BEST PRICE GUARANTEE</span>
            <p style="font-size:12pt;">When you book from the Official Aloha Kai Luau site, the price you pay is the best that is offered on the internet.</p>
        </div>
        <div class="HomeWhys">
            <img src="~/designs/alohakailuau/images/SSL.png" alt="Secure & Private"><br>
            <span id="HomeWhysTitles">SECURE & PRIVATE</span>
            <p style="font-size:12pt;">Aloha Kai Luau guarantees the security of its online bookings through encryption and protocols.</p>
        </div>
        <div class="HomeWhys">
            <img src="~/designs/alohakailuau/images/Seating.png" alt="Choice Seating"><br>
            <span id="HomeWhysTitles">CHOICE SEATING</span>
            <p style="font-size:12pt;">No other company that sells tickets to the Aloha Kai Luau can offer you this guarantee. Your order has priority over all other vendors that might also sell the Luau. Seats sell out quickly sometimes weeks in advance.</p>
        </div>



        <h2>Fun CULTURAL ACTIVITIES</h2>
        <p style="font-size:13pt;">Come and participate in some of the most cherished traditions of the islands during our interactive activities before the show! You'll get to see the ancient tradition of Polynesian tattooing, learn how to weave with coconut, play the ukulele, make a kupe'e, and learn about hula implements. At Sea Life Park luau you'll also have the opportunity to watch mini-performances such as coconut tree climbing, a coconut demonstration, and hulas performed during dinner.</p>


        <div class="content-slider-wrapper" id="cultural-slider">
            <div class="content-slider">
                <div class="slide">
                    <img src="~/designs/alohakailuau/images/Cultural1.jpg" id="HomeRotorImg" alt="Coconut Weaving">
                </div>
                <div class="slide">
                    <img src="~/designs/alohakailuau/images/Cultural2.jpg" id="HomeRotorImg" alt="Lei making">
                </div>
                <div class="slide">
                    <img src="~/designs/alohakailuau/images/Cultural3.jpg" id="HomeRotorImg" alt="Ukulele lesson">
                </div>
                <div class="slide">
                    <img src="~/designs/alohakailuau/images/Cultural4.jpg" id="HomeRotorImg" alt="Hula Lesson">
                </div>
                <div class="slide">
                    <img src="~/designs/alohakailuau/images/Cultural6.jpg" id="HomeRotorImg" alt="Coconut Weaving">
                </div>
                <div class="slide">
                    <img src="~/designs/alohakailuau/images/Cultural5.jpg" id="HomeRotorImg" alt="Kupe’e making">
                </div>
            </div>
        </div>


        <h2 style="margin-bottom:-3px;">ISLAND Style FEAST</h2>

        <span id="BlueMed">with UNEARTHING IMU CEREMONY</span>

        <p style="margin-top:6px;">A luau imu is a traditional Hawaiian underground oven used to cook food, usually a whole pig, for a luau feast. The pig is coated in salt and wrapped in banana leaves before being placed in a pit lined with hot rocks. The pit is then covered with sand, creating an oven-like environment that cooks the food slowly and evenly. The luau feast is a celebration that often includes traditional Hawaiian music, dance, and food. In addition to the pig cooked in the imu, the feast may also include other dishes such as poi, laulau, and haupia. The luau is a celebration of Hawaiian culture and is enjoyed by people of all ages. Experience a traditional Hawaiian luau dinner at Aloha Kai, Sea Life Park Luau.</p>


        <div class="content-slider-wrapper" id="feast-slider">
            <div class="content-slider">
                <div class="slide">
                    <img src="~/designs/alohakailuau/images/DinnerImu1.jpg" id="HomeRotorImg" alt="Imu demonstration">
                </div>
                <div class="slide">
                    <img src="~/designs/alohakailuau/images/DinnerImu3.jpg" id="HomeRotorImg" alt="Lomi Lomi Salmon">
                </div>
                <div class="slide">
                    <img src="~/designs/alohakailuau/images/DinnerImu5.jpg" id="HomeRotorImg" alt="Adult Beverages">
                </div>
                <div class="slide">
                    <img src="~/designs/alohakailuau/images/DinnerImu4.jpg" id="HomeRotorImg" alt="All You can eat Hawaiian buffet">
                </div>
                <div class="slide">
                    <img src="~/designs/alohakailuau/images/DinnerImu9.jpg" id="HomeRotorImg" alt="Desserts and Cakes">
                </div>
                <div class="slide">
                    <img src="~/designs/alohakailuau/images/DinnerImu8.jpg" id="HomeRotorImg" alt="Cookies">
                </div>
            </div>
        </div>

        <h2>Live POLYNESIAN Show</h2>

        <p style="font-size:13pt;">
            Overall, a Polynesian luau show is a vibrant and exciting cultural experience that combines music, dance, and food to give audiences a taste of the traditions of the Polynesian islands.<br /><br />

            One of the most exciting and visually impressive elements of a Polynesian luau show is fire knife dancing, also known as "siva afi" or "aisi." In this dance, the performer manipulates a long, burning knife or spear with fast-paced, precise movements, often in time to the music. Fire knife dancing is a thrilling and dangerous performance that requires skill, strength, and courage. It is a traditional dance that originated in Samoa and has been passed down through the generations. Sea Life Park Luau showcases these traditional island dances in their award-winning production.
        </p>


        <div class="content-slider-wrapper" id="show-slider">
            <div class="content-slider">
                <div class="slide">
                    <img src="~/designs/alohakailuau/images/PolyPerform3.jpg" id="HomeRotorImg" alt="Hawaiian Cultural Dances">
                </div>
                <div class="slide">
                    <img src="~/designs/alohakailuau/images/PolyPerform9.jpg" id="HomeRotorImg" alt="Fire Knife Dancers">
                </div>
                <div class="slide">
                    <img src="~/designs/alohakailuau/images/PolyPerform2.jpg" id="HomeRotorImg" alt="Samoana Dancers">
                </div>
                <div class="slide">
                    <img src="~/designs/alohakailuau/images/PolyPerform6.jpg" id="HomeRotorImg" alt="Tahitian Dancers">
                </div>
                <div class="slide">
                    <img src="~/designs/alohakailuau/images/PolyPerform5.jpg" id="HomeRotorImg" alt="Traditional Hawaiian Hula Dancing">
                </div>
                <div class="slide">
                    <img src="~/designs/alohakailuau/images/PolyPerform8.jpg" id="HomeRotorImg" alt="Fun Guest Appearances">
                </div>
                <div class="slide">
                    <img src="~/designs/alohakailuau/images/PolyPerform7.jpg" id="HomeRotorImg" alt="Samoana Dancers">
                </div>
                <div class="slide">
                    <img src="~/designs/alohakailuau/images/PolyPerform4.jpg" id="HomeRotorImg" alt="Hawaiian Cultural Dancing">
                </div>
            </div>
        </div>


        <h2>CUSTOMER TESTIMONIALS</h2>

        <div class="content-slider-wrapper dark-arrows" id="testimonial-slider">
            <div class="content-slider">
                <div class="slide">
                    <img src="~/designs/alohakailuau/images/test-slide3.jpg" alt="Oahu Luau Customer testimonial">
                </div>
                <div class="slide">
                    <img src="~/designs/alohakailuau/images/test-slide2.jpg" alt="Best Luau Customer testimonial">
                </div>
                <div class="slide">

                    <img src="~/designs/alohakailuau/images/Testimonial1.jpg" alt="Top Oahu Luau Review">
                </div>
                <div class="slide">
                    <img src="~/designs/alohakailuau/images/test-slide4.jpg" alt="Aloha Kai Customer testimonial">
                </div>
                <div class="slide">
                    <img src="~/designs/alohakailuau/images/test-slide5.jpg" alt="Sea Life Park Luau Customer testimonial">
                </div>
            </div>
        </div>
        <h3>LEAVE US A REVIEW</h3>
        <img src="~/designs/alohakailuau/images/Stars.png"><br>
        <a href="#"><img src="~/designs/alohakailuau/images/Tripadvisor.png" style="width: 125px; vertical-align: top;"></a>&nbsp;&nbsp;&nbsp;<a href="#"><img src="~/designs/alohakailuau/images/GoogleReviews.png" style="width: 76px; vertical-align: top;"></a>


        <br>
        <h2>Sea Life Park</h2>
        <br>
        <div class="SLPContentCont">
            <p>Aloha Kai Luau is located at iconic Sea Life Park Hawaii, Where the Heart Meets the Sea™.* Get inspired by amazing marine animals during a show or by observing them in their habitats! If you're looking for a more unique Hawaii experience, you can swim with dolphins, sharks, sea lions, or Hawaiian rays! *Included tickets to Sea Life Park Hawaii are General Admission. Bronze Package Tickets are valid for redemption one (1) day before or after luau date. Silver Package Tickets are valid for redemption five (5) days before or after luau date. Gold Package Tickets are valid for redemption ten (10) days before or after luau date. *Reservations not required for Luau guests. Visit park's main ticket office and show your Luau confirmation email to redeem! </p>
            <p>Sea Life Park is currently open DAILY from 10:00AM - 4:00PM</p>
        </div>
        <div class="SLPVideoCont">
            <iframe width="100%" height="315" src="https://www.youtube.com/embed/-LlPutbEJak" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
        </div>

    </div>
</div>

<script>
    const heroSlider = new KwikiSlider("hero-slider");
    const testimonialSlider = new KwikiSlider("testimonial-slider", {
        desktopTransitionMode: "slide"
    });
    const culturalSlider = new KwikiSlider("cultural-slider");
    const feastSlider = new KwikiSlider("feast-slider");
    const showSlider = new KwikiSlider("show-slider");
</script>


