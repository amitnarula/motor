<%@ Page Title="" Language="C#" MasterPageFile="~/motorprivate.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="motor.web.user.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <table width="50%">
        <colgroup>
            <col width="20%" />
            <col width="80%" />
        </colgroup>
       
        <tr>
            <td>
                <asp:Label Text="Firstname:" runat="server" /> </td>
            <td>
                <asp:TextBox runat="server" ID="txtFirstname" Enabled="false" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="Middlename:" runat="server" /> </td>
            <td>
                <asp:TextBox runat="server" ID="txtMiddlename" Enabled="false" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="Lastname:" runat="server" /> </td>
            <td>
                <asp:TextBox runat="server" ID="txtLastname" Enabled="false" />
            </td>
        </tr>
       <tr>
            <td>
                <asp:Label Text="Email:" runat="server" /> </td>
            <td>
                <asp:TextBox runat="server" ID="txtEmail" Enabled="false" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="Phone:" runat="server" /> </td>
            <td>
                <asp:TextBox runat="server" ID="txtPhone" Enabled="false" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="City:" runat="server" /> </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlCity">

                    <asp:ListItem Text="Abington,MA" />
                    <asp:ListItem Text="Acton,MA" />
                    <asp:ListItem Text="Acushnet,MA" />
                    <asp:ListItem Text="Adams,MA" />
                    <asp:ListItem Text="Agawam,MA" />
                    <asp:ListItem Text="Allston,MA" />
                    <asp:ListItem Text="Amesbury,MA" />
                    <asp:ListItem Text="Andover,MA" />
                    <asp:ListItem Text="Arlington,MA" />
                    <asp:ListItem Text="Ashburnham,MA" />
                    <asp:ListItem Text="Ashby,MA" />
                    <asp:ListItem Text="Ashfield,MA" />
                    <asp:ListItem Text="Ashland,MA" />
                    <asp:ListItem Text="Ashley Falls,MA" />
                    <asp:ListItem Text="Assonet,MA" />
                    <asp:ListItem Text="Attleboro,MA" />
                    <asp:ListItem Text="Auburn,MA" />
                    <asp:ListItem Text="Auburndale,MA" />
                    <asp:ListItem Text="Avon,MA" />
                    <asp:ListItem Text="Ayer,MA" />
                    <asp:ListItem Text="Baldwinville,MA" />
                    <asp:ListItem Text="Barnstable,MA" />
                    <asp:ListItem Text="Barre,MA" />
                    <asp:ListItem Text="Bass River,MA" />
                    <asp:ListItem Text="Becket,MA" />
                    <asp:ListItem Text="Bedford,MA" />
                    <asp:ListItem Text="Belchertown,MA" />
                    <asp:ListItem Text="Bellingham,MA" />
                    <asp:ListItem Text="Belmont,MA" />
                    <asp:ListItem Text="Berkley,MA" />
                    <asp:ListItem Text="Berlin,MA" />
                    <asp:ListItem Text="Beverly,MA" />
                    <asp:ListItem Text="Billerica,MA" />
                    <asp:ListItem Text="Blackstone,MA" />
                    <asp:ListItem Text="Blandford,MA" />
                    <asp:ListItem Text="Bolton,MA" />
                    <asp:ListItem Text="Boston,MA" />
                    <asp:ListItem Text="Boston College,MA" />
                    <asp:ListItem Text="Boxboro,MA" />
                    <asp:ListItem Text="Boxford,MA" />
                    <asp:ListItem Text="Boylston,MA" />
                    <asp:ListItem Text="Bradford,MA" />
                    <asp:ListItem Text="Braintree,MA" />
                    <asp:ListItem Text="Brewster,MA" />
                    <asp:ListItem Text="Bridgewater,MA" />
                    <asp:ListItem Text="Brighton,MA" />
                    <asp:ListItem Text="Brimfield,MA" />
                    <asp:ListItem Text="Brockton,MA" />
                    <asp:ListItem Text="Brookfield,MA" />
                    <asp:ListItem Text="Brookline,MA" />
                    <asp:ListItem Text="Buckland,MA" />
                    <asp:ListItem Text="Burlington,MA" />
                    <asp:ListItem Text="Byfield,MA" />
                    <asp:ListItem Text="Cambridge,MA" />
                    <asp:ListItem Text="Canton,MA" />
                    <asp:ListItem Text="Carlisle,MA" />
                    <asp:ListItem Text="Carver,MA" />
                    <asp:ListItem Text="Centerville,MA" />
                    <asp:ListItem Text="Charlestown,MA" />
                    <asp:ListItem Text="Charlton,MA" />
                    <asp:ListItem Text="Chelsea,MA" />
                    <asp:ListItem Text="Cherry Valley,MA" />
                    <asp:ListItem Text="Cheshire,MA" />
                    <asp:ListItem Text="Chester,MA" />
                    <asp:ListItem Text="Chesterfield,MA" />
                    <asp:ListItem Text="Chicopee,MA" />
                    <asp:ListItem Text="Chilmark,MA" />
                    <asp:ListItem Text="Clarksburg,MA" />
                    <asp:ListItem Text="Clinton,MA" />
                    <asp:ListItem Text="Cohasset,MA" />
                    <asp:ListItem Text="Colrain,MA" />
                    <asp:ListItem Text="Concord,MA" />
                    <asp:ListItem Text="Conway,MA" />
                    <asp:ListItem Text="Cotuit,MA" />
                    <asp:ListItem Text="Cummington,MA" />
                    <asp:ListItem Text="Cushman,MA" />
                    <asp:ListItem Text="Cuttyhunk,MA" />
                    <asp:ListItem Text="Dalton,MA" />
                    <asp:ListItem Text="Danvers,MA" />
                    <asp:ListItem Text="Dedham,MA" />
                    <asp:ListItem Text="Deerfield,MA" />
                    <asp:ListItem Text="Dennis,MA" />
                    <asp:ListItem Text="Dennis Port,MA" />
                    <asp:ListItem Text="Dighton,MA" />
                    <asp:ListItem Text="Dorchester,MA" />
                    <asp:ListItem Text="Dover,MA" />
                    <asp:ListItem Text="Dracut,MA" />
                    <asp:ListItem Text="Dudley,MA" />
                    <asp:ListItem Text="Dudley Hill,MA" />
                    <asp:ListItem Text="Dunstable,MA" />
                    <asp:ListItem Text="Duxbury,MA" />
                    <asp:ListItem Text="East Boston,MA" />
                    <asp:ListItem Text="East Bridgewater,MA" />
                    <asp:ListItem Text="East Brookfield,MA" />
                    <asp:ListItem Text="East Cambridge,MA" />
                    <asp:ListItem Text="East Douglas,MA" />
                    <asp:ListItem Text="East Freetown,MA" />
                    <asp:ListItem Text="East Longmeadow,MA" />
                    <asp:ListItem Text="East Lynn,MA" />
                    <asp:ListItem Text="East Sandwich,MA" />
                    <asp:ListItem Text="East Taunton,MA" />
                    <asp:ListItem Text="East Walpole,MA" />
                    <asp:ListItem Text="East Wareham,MA" />
                    <asp:ListItem Text="East Watertown,MA" />
                    <asp:ListItem Text="Eastham,MA" />
                    <asp:ListItem Text="Edgartown,MA" />
                    <asp:ListItem Text="Erving,MA" />
                    <asp:ListItem Text="Essex,MA" />
                    <asp:ListItem Text="Everett,MA" />
                    <asp:ListItem Text="Fairhaven,MA" />
                    <asp:ListItem Text="Fall River,MA" />
                    <asp:ListItem Text="Falmouth,MA" />
                    <asp:ListItem Text="Feeding Hills,MA" />
                    <asp:ListItem Text="Fiskdale,MA" />
                    <asp:ListItem Text="Fitchburg,MA" />
                    <asp:ListItem Text="Florence,MA" />
                    <asp:ListItem Text="Forestdale,MA" />
                    <asp:ListItem Text="Foxboro,MA" />
                    <asp:ListItem Text="Framingham,MA" />
                    <asp:ListItem Text="Franklin,MA" />
                    <asp:ListItem Text="Ft Devens,MA" />
                    <asp:ListItem Text="Gardner,MA" />
                    <asp:ListItem Text="Georgetown,MA" />
                    <asp:ListItem Text="Gilbertville,MA" />
                    <asp:ListItem Text="Gloucester,MA" />
                    <asp:ListItem Text="Goshen,MA" />
                    <asp:ListItem Text="Grafton,MA" />
                    <asp:ListItem Text="Granby,MA" />
                    <asp:ListItem Text="Graniteville,MA" />
                    <asp:ListItem Text="Great Barrington,MA" />
                    <asp:ListItem Text="Groton,MA" />
                    <asp:ListItem Text="Groveland,MA" />
                    <asp:ListItem Text="Hadley,MA" />
                    <asp:ListItem Text="Halifax,MA" />
                    <asp:ListItem Text="Hampden,MA" />
                    <asp:ListItem Text="Hancock,MA" />
                    <asp:ListItem Text="Hanover,MA" />
                    <asp:ListItem Text="Hanson,MA" />
                    <asp:ListItem Text="Harvard,MA" />
                    <asp:ListItem Text="Harwich,MA" />
                    <asp:ListItem Text="Harwich Port,MA" />
                    <asp:ListItem Text="Hatfield,MA" />
                    <asp:ListItem Text="Haverhill,MA" />
                    <asp:ListItem Text="Hawley,MA" />
                    <asp:ListItem Text="Haydenville,MA" />
                    <asp:ListItem Text="Heath,MA" />
                    <asp:ListItem Text="Hingham,MA" />
                    <asp:ListItem Text="Holbrook,MA" />
                    <asp:ListItem Text="Holden,MA" />
                    <asp:ListItem Text="Holland,MA" />
                    <asp:ListItem Text="Holliston,MA" />
                    <asp:ListItem Text="Holyoke,MA" />
                    <asp:ListItem Text="Hopedale,MA" />
                    <asp:ListItem Text="Hopkinton,MA" />
                    <asp:ListItem Text="Housatonic,MA" />
                    <asp:ListItem Text="Hubbardston,MA" />
                    <asp:ListItem Text="Hudson,MA" />
                    <asp:ListItem Text="Hull,MA" />
                    <asp:ListItem Text="Huntington,MA" />
                    <asp:ListItem Text="Hyde Park,MA" />
                    <asp:ListItem Text="Indian Orchard,MA" />
                    <asp:ListItem Text="Ipswich,MA" />
                    <asp:ListItem Text="Jamaica Plain,MA" />
                    <asp:ListItem Text="Jefferson,MA" />
                    <asp:ListItem Text="Kingston,MA" />
                    <asp:ListItem Text="Lakeville,MA" />
                    <asp:ListItem Text="Lancaster,MA" />
                    <asp:ListItem Text="Lawrence,MA" />
                    <asp:ListItem Text="Lee,MA" />
                    <asp:ListItem Text="Leeds,MA" />
                    <asp:ListItem Text="Leicester,MA" />
                    <asp:ListItem Text="Lenox,MA" />
                    <asp:ListItem Text="Leominster,MA" />
                    <asp:ListItem Text="Leverett,MA" />
                    <asp:ListItem Text="Lexington,MA" />
                    <asp:ListItem Text="Leyden,MA" />
                    <asp:ListItem Text="Lincoln,MA" />
                    <asp:ListItem Text="Littleton,MA" />
                    <asp:ListItem Text="Longmeadow,MA" />
                    <asp:ListItem Text="Lowell,MA" />
                    <asp:ListItem Text="Ludlow,MA" />
                    <asp:ListItem Text="Lunenburg,MA" />
                    <asp:ListItem Text="Lynn,MA" />
                    <asp:ListItem Text="Lynnfield,MA" />
                    <asp:ListItem Text="Malden,MA" />
                    <asp:ListItem Text="Manchester,MA" />
                    <asp:ListItem Text="Mansfield,MA" />
                    <asp:ListItem Text="Marblehead,MA" />
                    <asp:ListItem Text="Marion,MA" />
                    <asp:ListItem Text="Marlborough,MA" />
                    <asp:ListItem Text="Marshfield,MA" />
                    <asp:ListItem Text="Marstons Mills,MA" />
                    <asp:ListItem Text="Mashpee,MA" />
                    <asp:ListItem Text="Mattapan,MA" />
                    <asp:ListItem Text="Mattapoisett,MA" />
                    <asp:ListItem Text="Maynard,MA" />
                    <asp:ListItem Text="Medfield,MA" />
                    <asp:ListItem Text="Medford,MA" />
                    <asp:ListItem Text="Medway,MA" />
                    <asp:ListItem Text="Melrose,MA" />
                    <asp:ListItem Text="Mendon,MA" />
                    <asp:ListItem Text="Merrimac,MA" />
                    <asp:ListItem Text="Methuen,MA" />
                    <asp:ListItem Text="Middleboro,MA" />
                    <asp:ListItem Text="Middlefield,MA" />
                    <asp:ListItem Text="Middleton,MA" />
                    <asp:ListItem Text="Milford,MA" />
                    <asp:ListItem Text="Millbury,MA" />
                    <asp:ListItem Text="Millers Falls,MA" />
                    <asp:ListItem Text="Millis,MA" />
                    <asp:ListItem Text="Millville,MA" />
                    <asp:ListItem Text="Milton,MA" />
                    <asp:ListItem Text="Monroe,MA" />
                    <asp:ListItem Text="Monson,MA" />
                    <asp:ListItem Text="Montague,MA" />
                    <asp:ListItem Text="Montgomery,MA" />
                    <asp:ListItem Text="Mount Tom,MA" />
                    <asp:ListItem Text="Nahant,MA" />
                    <asp:ListItem Text="Nantucket,MA" />
                    <asp:ListItem Text="Natick,MA" />
                    <asp:ListItem Text="Needham,MA" />
                    <asp:ListItem Text="New Bedford,MA" />
                    <asp:ListItem Text="New Braintree,MA" />
                    <asp:ListItem Text="New Salem,MA" />
                    <asp:ListItem Text="Newbury,MA" />
                    <asp:ListItem Text="Newburyport,MA" />
                    <asp:ListItem Text="Newton Center,MA" />
                    <asp:ListItem Text="Newton Highlands,MA" />
                    <asp:ListItem Text="Newton Upper Fal,MA" />
                    <asp:ListItem Text="Newtonville,MA" />
                    <asp:ListItem Text="Norfolk,MA" />
                    <asp:ListItem Text="North Andover,MA" />
                    <asp:ListItem Text="North Attleboro,MA" />
                    <asp:ListItem Text="North Billerica,MA" />
                    <asp:ListItem Text="North Brookfield,MA" />
                    <asp:ListItem Text="North Cambridge,MA" />
                    <asp:ListItem Text="North Chatham,MA" />
                    <asp:ListItem Text="North Chelmsford,MA" />
                    <asp:ListItem Text="North Dartmouth,MA" />
                    <asp:ListItem Text="North Dighton,MA" />
                    <asp:ListItem Text="North Easton,MA" />
                    <asp:ListItem Text="North Falmouth,MA" />
                    <asp:ListItem Text="North Grafton,MA" />
                    <asp:ListItem Text="North Oxford,MA" />
                    <asp:ListItem Text="North Reading,MA" />
                    <asp:ListItem Text="North Truro,MA" />
                    <asp:ListItem Text="North Waltham,MA" />
                    <asp:ListItem Text="Northborough,MA" />
                    <asp:ListItem Text="Northbridge,MA" />
                    <asp:ListItem Text="Northfield,MA" />
                    <asp:ListItem Text="Norton,MA" />
                    <asp:ListItem Text="Norwell,MA" />
                    <asp:ListItem Text="Norwood,MA" />
                    <asp:ListItem Text="Oakham,MA" />
                    <asp:ListItem Text="Onset,MA" />
                    <asp:ListItem Text="Orleans,MA" />
                    <asp:ListItem Text="Osterville,MA" />
                    <asp:ListItem Text="Otis,MA" />
                    <asp:ListItem Text="Otis A F B,MA" />
                    <asp:ListItem Text="Oxford,MA" />
                    <asp:ListItem Text="Padanaram Villag,MA" />
                    <asp:ListItem Text="Palmer,MA" />
                    <asp:ListItem Text="Paxton,MA" />
                    <asp:ListItem Text="Peabody,MA" />
                    <asp:ListItem Text="Pembroke,MA" />
                    <asp:ListItem Text="Pepperell,MA" />
                    <asp:ListItem Text="Peru,MA" />
                    <asp:ListItem Text="Petersham,MA" />
                    <asp:ListItem Text="Pittsfield,MA" />
                    <asp:ListItem Text="Plainfield,MA" />
                    <asp:ListItem Text="Plainville,MA" />
                    <asp:ListItem Text="Plymouth,MA" />
                    <asp:ListItem Text="Plympton,MA" />
                    <asp:ListItem Text="Pocasset,MA" />
                    <asp:ListItem Text="Princeton,MA" />
                    <asp:ListItem Text="Provincetown,MA" />
                    <asp:ListItem Text="Quincy,MA" />
                    <asp:ListItem Text="Randolph,MA" />
                    <asp:ListItem Text="Raynham,MA" />
                    <asp:ListItem Text="Reading,MA" />
                    <asp:ListItem Text="Rehoboth,MA" />
                    <asp:ListItem Text="Revere,MA" />
                    <asp:ListItem Text="Richmond,MA" />
                    <asp:ListItem Text="Rochdale,MA" />
                    <asp:ListItem Text="Rochester,MA" />
                    <asp:ListItem Text="Rockland,MA" />
                    <asp:ListItem Text="Rockport,MA" />
                    <asp:ListItem Text="Roslindale,MA" />
                    <asp:ListItem Text="Rowe,MA" />
                    <asp:ListItem Text="Rowley,MA" />
                    <asp:ListItem Text="Roxbury,MA" />
                    <asp:ListItem Text="Russell,MA" />
                    <asp:ListItem Text="Rutland,MA" />
                    <asp:ListItem Text="Salem,MA" />
                    <asp:ListItem Text="Salisbury,MA" />
                    <asp:ListItem Text="Sandisfield,MA" />
                    <asp:ListItem Text="Sandwich,MA" />
                    <asp:ListItem Text="Saugus,MA" />
                    <asp:ListItem Text="Savoy,MA" />
                    <asp:ListItem Text="Scituate,MA" />
                    <asp:ListItem Text="Seekonk,MA" />
                    <asp:ListItem Text="Sharon,MA" />
                    <asp:ListItem Text="Sheffield,MA" />
                    <asp:ListItem Text="Shelburne Falls,MA" />
                    <asp:ListItem Text="Sherborn,MA" />
                    <asp:ListItem Text="Shirley Center,MA" />
                    <asp:ListItem Text="Shrewsbury,MA" />
                    <asp:ListItem Text="Shutesbury,MA" />
                    <asp:ListItem Text="Somerset,MA" />
                    <asp:ListItem Text="Somerville,MA" />
                    <asp:ListItem Text="South Boston,MA" />
                    <asp:ListItem Text="South Chatham,MA" />
                    <asp:ListItem Text="South Chelmsford,MA" />
                    <asp:ListItem Text="South Deerfield,MA" />
                    <asp:ListItem Text="South Dennis,MA" />
                    <asp:ListItem Text="South Easton,MA" />
                    <asp:ListItem Text="South Egremont,MA" />
                    <asp:ListItem Text="South Grafton,MA" />
                    <asp:ListItem Text="South Hadley,MA" />
                    <asp:ListItem Text="South Hamilton,MA" />
                    <asp:ListItem Text="South Walpole,MA" />
                    <asp:ListItem Text="Southampton,MA" />
                    <asp:ListItem Text="Southborough,MA" />
                    <asp:ListItem Text="Southbridge,MA" />
                    <asp:ListItem Text="Southfield,MA" />
                    <asp:ListItem Text="Southwick,MA" />
                    <asp:ListItem Text="Spencer,MA" />
                    <asp:ListItem Text="Springfield,MA" />
                    <asp:ListItem Text="Sterling,MA" />
                    <asp:ListItem Text="Stockbridge,MA" />
                    <asp:ListItem Text="Stoneham,MA" />
                    <asp:ListItem Text="Stoughton,MA" />
                    <asp:ListItem Text="Stow,MA" />
                    <asp:ListItem Text="Sturbridge,MA" />
                    <asp:ListItem Text="Sudbury,MA" />
                    <asp:ListItem Text="Sunderland,MA" />
                    <asp:ListItem Text="Swampscott,MA" />
                    <asp:ListItem Text="Swansea,MA" />
                    <asp:ListItem Text="Taunton,MA" />
                    <asp:ListItem Text="Teaticket,MA" />
                    <asp:ListItem Text="Templeton,MA" />
                    <asp:ListItem Text="Tewksbury,MA" />
                    <asp:ListItem Text="Three Rivers,MA" />
                    <asp:ListItem Text="Tolland,MA" />
                    <asp:ListItem Text="Topsfield,MA" />
                    <asp:ListItem Text="Townsend,MA" />
                    <asp:ListItem Text="Truro,MA" />
                    <asp:ListItem Text="Turners Falls,MA" />
                    <asp:ListItem Text="Tyngsboro,MA" />
                    <asp:ListItem Text="Uxbridge,MA" />
                    <asp:ListItem Text="Village Of Nagog,MA" />
                    <asp:ListItem Text="Vineyard Haven,MA" />
                    <asp:ListItem Text="W Townsend,MA" />
                    <asp:ListItem Text="Waban,MA" />
                    <asp:ListItem Text="Wakefield,MA" />
                    <asp:ListItem Text="Wales,MA" />
                    <asp:ListItem Text="Walpole,MA" />
                    <asp:ListItem Text="Ware,MA" />
                    <asp:ListItem Text="Wareham,MA" />
                    <asp:ListItem Text="Wayland,MA" />
                    <asp:ListItem Text="Wellesley,MA" />
                    <asp:ListItem Text="Wellfleet,MA" />
                    <asp:ListItem Text="Wendell,MA" />
                    <asp:ListItem Text="Wenham,MA" />
                    <asp:ListItem Text="West Barnstable,MA" />
                    <asp:ListItem Text="West Boylston,MA" />
                    <asp:ListItem Text="West Bridgewater,MA" />
                    <asp:ListItem Text="West Brookfield,MA" />
                    <asp:ListItem Text="West Dennis,MA" />
                    <asp:ListItem Text="West Harwich,MA" />
                    <asp:ListItem Text="West Lynn,MA" />
                    <asp:ListItem Text="West Newbury,MA" />
                    <asp:ListItem Text="West Otis,MA" />
                    <asp:ListItem Text="West Roxbury,MA" />
                    <asp:ListItem Text="West Springfield,MA" />
                    <asp:ListItem Text="West Stockbridge,MA" />
                    <asp:ListItem Text="West Tisbury,MA" />
                    <asp:ListItem Text="West Upton,MA" />
                    <asp:ListItem Text="West Wareham,MA" />
                    <asp:ListItem Text="West Warren,MA" />
                    <asp:ListItem Text="West Yarmouth,MA" />
                    <asp:ListItem Text="Westborough,MA" />
                    <asp:ListItem Text="Westminster,MA" />
                    <asp:ListItem Text="Weston,MA" />
                    <asp:ListItem Text="Westover Afb,MA" />
                    <asp:ListItem Text="Westport,MA" />
                    <asp:ListItem Text="Westwood,MA" />
                    <asp:ListItem Text="Weymouth,MA" />
                    <asp:ListItem Text="Whitinsville,MA" />
                    <asp:ListItem Text="Whitman,MA" />
                    <asp:ListItem Text="Wilbraham,MA" />
                    <asp:ListItem Text="Wilkinsonville,MA" />
                    <asp:ListItem Text="Williamsburg,MA" />
                    <asp:ListItem Text="Williamstown,MA" />
                    <asp:ListItem Text="Wilmington,MA" />
                    <asp:ListItem Text="Winchendon,MA" />
                    <asp:ListItem Text="Winchester,MA" />
                    <asp:ListItem Text="Windsor,MA" />
                    <asp:ListItem Text="Winthrop,MA" />
                    <asp:ListItem Text="Woburn,MA" />
                    <asp:ListItem Text="Woods Hole,MA" />
                    <asp:ListItem Text="Worcester,MA" />
                    <asp:ListItem Text="Worthington,MA" />
                    <asp:ListItem Text="Wrentham,MA" />
                    <asp:ListItem Text="Yarmouth Port,MA" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button Text="Save" ID="btnSaveProfile" runat="server" OnClick="btnSaveProfile_Click" ValidationGroup="gpProfile" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="Change Password:" runat="server" /> </td>
            <td>
                <table>
                    <tr>
                        <td>
                            <asp:Label Text="Old password:" runat="server" /> </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtOldPassword" TextMode="Password" MaxLength="8" />
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ErrorMessage="Please enter old password" ControlToValidate="txtOldPassword" ValidationGroup="gpChangePassword" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label Text="New password:" runat="server" /> </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtNewPassword" TextMode="Password" MaxLength="8" />
                        </td>
                        <td><asp:RequiredFieldValidator ErrorMessage="Please enter new password" ControlToValidate="txtNewPassword" ValidationGroup="gpChangePassword" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label Text="Confirm password:" runat="server" /> </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtConfirmPassword" TextMode="Password" MaxLength="8" />
                        </td>
                        <td><asp:RequiredFieldValidator ErrorMessage="Please enter confirm password" ControlToValidate="txtConfirmPassword" ValidationGroup="gpChangePassword" Display="Dynamic" runat="server" />
                            <asp:CompareValidator ErrorMessage="New and confirm password don't match" ControlToValidate="txtNewPassword" ValidationGroup="gpChangePassword" ControlToCompare="txtConfirmPassword" Display="Dynamic" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button Text="Change password:" ID="btnChangePassword" runat="server" ValidationGroup="gpChangePassword" OnClick="btnChangePassword_Click" /> </td>
        </tr>
        
        <tr>
            <td></td>
            <td>
                <asp:Label Text="" ID="lblMessage" runat="server" /> </td>
        </tr>
        
    </table>
</asp:Content>
