<!--#include file="partials/_registers.ascx" -->
<!--#include file="partials/_includes.ascx" -->

<!-- Header/NavBar -->

<!--#include file="partials/_header-no-navigation.ascx" -->



<!-- Main Content -->
<main id="maincontent">
    <section class="nhsuk-hero">
        <div class="nhsuk-width-container nhsuk-hero--border">
            <div class="nhsuk-grid-row">
                <div class="nhsuk-grid-column-two-thirds">
                    <div class="nhsuk-hero__wrapper">
                        <h1 class="nhsuk-u-margin-bottom-3"><%=PortalSettings.ActiveTab.TabName %> </h1>
                        <p class="nhsuk-body-l nhsuk-u-margin-bottom-0"><%=PortalSettings.ActiveTab.Description %></p>

                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class="nhsuk-section">
        <div class="nhsuk-width-container">
            <div id="ContentPane" class="nhsuk-grid-row nhsuk-promo-group" runat="server">
            </div>
        </div>
    </section>


    <section class="nhsuk-section nhsuk-section--white">
        <div class="nhsuk-width-container">
            <div class="nhsuk-grid-row">
                <div class="nhsuk-grid-column-one-half" runat="server" id="RowL_Half_Pane">

                </div>
                <div class="nhsuk-grid-column-one-half" runat="server" id="RowR_Half_Pane">

                </div>
            </div>
        </div>
    </section>

</main>

<!-- Footer -->
<!--#include file="partials/_footer.ascx" -->

