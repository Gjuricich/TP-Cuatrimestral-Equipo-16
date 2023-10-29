<%@ Page Title="" Language="C#" MasterPageFile="~/Cab.Master" AutoEventWireup="true" CodeBehind="AskedQuestions.aspx.cs" Inherits="CabWeb.AskedQuestions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1 class="Asked text-center" style="margin-top: 2%; margin-bottom: 2%"><strong>Frequently Asked Questions</strong></h1>

    <div class="accordion accordion-flush" id="accordionFlushExample" style="margin-left: 10%; margin-right: 10%; margin-bottom: 2%;">

        <div class="accordion-item">
            <h2 class="accordion-header">
                <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapseOne" aria-expanded="false" aria-controls="flush-collapseOne" style="font-size:20px;">
                    LALA
                </button>
            </h2>
            <div id="flush-collapseOne" class="accordion-collapse collapse" data-bs-parent="#accordionFlush">
                <div class="accordion-body">Lorem, ipsum dolor sit amet consectetur adipisicing elit. Cupiditate nobis quo modi tenetur sed consequuntur suscipit voluptatum omnis optio, minima a odio quibusdam alias! At debitis placeat quis voluptate ducimus?</div>
            </div>
        </div>
        <div class="accordion-item">
            <h2 class="accordion-header">
                <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapseTwo" aria-expanded="false" aria-controls="flush-collapseTwo" style="font-size:20px;">
                   LALA
                </button>
            </h2>
            <div id="flush-collapseTwo" class="accordion-collapse collapse" data-bs-parent="#accordionFlush">
                <div class="accordion-body">Lorem, ipsum dolor sit amet consectetur adipisicing elit. Cupiditate nobis quo modi tenetur sed consequuntur suscipit voluptatum omnis optio, minima a odio quibusdam alias! At debitis placeat quis voluptate ducimus?</div>
            </div>
        </div>
        <div class="accordion-item">
            <h2 class="accordion-header">
                <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapseThree" aria-expanded="false" aria-controls="flush-collapseThree" style="font-size:20px;">
                   LALALA
                </button>
            </h2>
            <div id="flush-collapseThree" class="accordion-collapse collapse" data-bs-parent="#accordionFlush">
                <div class="accordion-body">Lorem, ipsum dolor sit amet consectetur adipisicing elit. Cupiditate nobis quo modi tenetur sed consequuntur suscipit voluptatum omnis optio, minima a odio quibusdam alias! At debitis placeat quis voluptate ducimus?</div>
            </div>
        </div>
        <div class="accordion-item">
            <h2 class="accordion-header">
                <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapseFor" aria-expanded="false" aria-controls="flush-collapseFor" style="font-size:20px;">
                    LALALA
                </button>
            </h2>
            <div id="flush-collapseFor" class="accordion-collapse collapse" data-bs-parent="#accordionFlush">
                <div class="accordion-body">Lorem, ipsum dolor sit amet consectetur adipisicing elit. Cupiditate nobis quo modi tenetur sed consequuntur suscipit voluptatum omnis optio, minima a odio quibusdam alias! At debitis placeat quis voluptate ducimus?</div>
            </div>
        </div>
        <div class="accordion-item">
            <h2 class="accordion-header">
                <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapseFive" aria-expanded="false" aria-controls="flush-collapseFive" style="font-size:20px;">
                   LALALALA
                </button>
            </h2>
            <div id="flush-collapseFive" class="accordion-collapse collapse" data-bs-parent="#accordionFlush">
                <div class="accordion-body">Lorem, ipsum dolor sit amet consectetur adipisicing elit. Cupiditate nobis quo modi tenetur sed consequuntur suscipit voluptatum omnis optio, minima a odio quibusdam alias! At debitis placeat quis voluptate ducimus?</div>
            </div>
        </div>
    </div>

    <a href="Default.aspx" class="btn btn-primary">Back</a>
</asp:Content>
