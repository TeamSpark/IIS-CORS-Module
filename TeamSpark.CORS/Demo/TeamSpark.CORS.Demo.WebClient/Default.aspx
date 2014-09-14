<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TeamSpark.CORS.Demo.WebClient._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<script type="text/javascript" src="/Scripts/jquery-1.7.1.min.js"></script>
</head>
<body>
	<div>
		<button onclick="callService()">click to call web service</button>
		<p id="lbMessage"></p>
	</div>

	<script type="text/javascript">
		function callService() {
			var label = $('#lbMessage');
			var url = 'http://localhost:50101/myservice.asmx/HelloWorld';

			label.text('we are calling web service...');

			$.ajax({
				type: "POST",
				url: url
			})
			.done(function (msg) {
				// here we have an ugly hack because web service resonse is in xml format
				label.text(msg.childNodes[0].childNodes[0].data);
			});
		}
	</script>
</body>
</html>
