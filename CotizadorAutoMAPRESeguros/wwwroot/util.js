window.showPdfFromBase64 = (base64String, filename = 'download.pdf') => {
    const binaryString = atob(base64String);
    const binaryLen = binaryString.length;
    const bytes = new Uint8Array(binaryLen);
    for (let i = 0; i < binaryLen; i++) {
        bytes[i] = binaryString.charCodeAt(i);
    }
    const blob = new Blob([bytes], { type: "application/pdf" });
    const link = document.createElement('a');
    link.href = window.URL.createObjectURL(blob);
    
    link.download = filename
    link.target = '_blank';
    link.click();
}

window.showExcelFromBase64 = (base64String, filename = 'download.xlsx') => {
    const binaryString = atob(base64String);
    const binaryLen = binaryString.length;
    const bytes = new Uint8Array(binaryLen);
    for (let i = 0; i < binaryLen; i++) {
        bytes[i] = binaryString.charCodeAt(i);
    }
    const blob = new Blob([bytes], { type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" });
    const link = document.createElement('a');
    link.href = window.URL.createObjectURL(blob);
    link.download = filename;
    link.target = '_blank';
    link.click();
}

// Use it for .NET 6+
function BlazorDownloadFile(filename, contentType, content) {
    // Create the URL
    const file = new File([content], filename, { type: contentType });
    const exportUrl = URL.createObjectURL(file);

    // Create the <a> element and click on it
    const a = document.createElement("a");
    document.body.appendChild(a);
    a.href = exportUrl;
    a.download = filename;
    a.target = "_self";
    a.click();

    // We don't need to keep the object URL, let's release the memory
    // On older versions of Safari, it seems you need to comment this line...
    URL.revokeObjectURL(exportUrl);
}

function getSelectOptions () {
    // Obtener el elemento select

    var selectElement = document.getElementById('dboEmpresa');
    // Obtener todas las opciones dentro del select

    var options = selectElement.options;

    // Crear un array para almacenar los atributos personalizados de cada opción
    var customAttributes = [];

    // Iterar sobre todas las opciones y obtener el valor del atributo personalizado
    for (var i = 0; i < options.length; i++) {
        var option = options[i];
        var customAttribute = option.getAttribute('tipo');
        customAttributes.push(customAttribute);
    }

    // Retornar el array de atributos personalizados
    return customAttributes;
};

window.isMobile = () => {
    return window.innerWidth <= 768; // Puedes ajustar este umbral según tu necesidad
};

window.deviceDetector = {
    initialize: function (dotNetObject) {
        function checkSize() {
            const isMobile = window.innerWidth <= 768; // Puedes ajustar el umbral
            dotNetObject.invokeMethodAsync("OnResize", isMobile);
        }

        window.addEventListener("resize", checkSize);

        // Llamar al inicio también
        checkSize();
    }
};

window.launchConfetti = () => {
    confetti({
        particleCount: 100,
        spread: 170,
        origin: { y: 0.6 }
    });
};