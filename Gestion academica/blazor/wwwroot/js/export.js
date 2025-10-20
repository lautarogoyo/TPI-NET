// wwwroot/js/export.js
(function () {
    function loadScript(src) {
        return new Promise((resolve, reject) => {
            // Evita duplicar scripts
            if (document.querySelector(`script[src="${src}"]`)) return resolve();
            const s = document.createElement("script");
            s.src = src;
            s.async = true;
            s.onload = () => resolve();
            s.onerror = () => reject(new Error("No se pudo cargar: " + src));
            document.head.appendChild(s);
        });
    }

    async function ensureJsPdfAndAutoTable() {
        // jsPDF UMD expone window.jspdf.jsPDF
        if (!window.jspdf || !window.jspdf.jsPDF) {
            await loadScript("https://cdnjs.cloudflare.com/ajax/libs/jspdf/2.5.1/jspdf.umd.min.js");
            // pequeño wait para inicialización
            for (let i = 0; i < 20 && (!window.jspdf || !window.jspdf.jsPDF); i++) {
                await new Promise(r => setTimeout(r, 25));
            }
        }
        if (!window.jspdf || !window.jspdf.jsPDF) {
            throw new Error("jsPDF no se inicializó");
        }

        // autoTable se agrega como doc.autoTable o jsPDF.API.autoTable
        const hasAutoTable =
            (window.jspdf.jsPDF && window.jspdf.jsPDF.API && window.jspdf.jsPDF.API.autoTable);

        if (!hasAutoTable) {
            await loadScript("https://cdnjs.cloudflare.com/ajax/libs/jspdf-autotable/3.5.29/jspdf.plugin.autotable.min.js");
            for (let i = 0; i < 20; i++) {
                const ok = (window.jspdf.jsPDF && window.jspdf.jsPDF.API && window.jspdf.jsPDF.API.autoTable);
                if (ok) break;
                await new Promise(r => setTimeout(r, 25));
            }
        }

        if (!(window.jspdf.jsPDF && window.jspdf.jsPDF.API && window.jspdf.jsPDF.API.autoTable)) {
            throw new Error("jsPDF-AutoTable no se inicializó");
        }
    }

    window.exportTableToPdf = async function (title, selector) {
        await ensureJsPdfAndAutoTable();

        const { jsPDF } = window.jspdf;
        const doc = new jsPDF({ orientation: "portrait", unit: "pt", format: "a4" });

        const pageWidth = doc.internal.pageSize.getWidth();
        const pageHeight = doc.internal.pageSize.getHeight();

        // Header
        doc.setFontSize(14);
        doc.text(String(title || "Export"), 40, 40);
        doc.setFontSize(10);
        doc.text(new Date().toLocaleString(), 40, 58);

        // Tabla desde el DOM
        if (!document.querySelector(selector)) {
            throw new Error("No se encontró la tabla con selector: " + selector);
        }

        doc.autoTable({
            html: selector,
            startY: 80,
            styles: { fontSize: 9, cellPadding: 4 },
            headStyles: { fillColor: [33, 37, 41], textColor: 255 },
            didDrawPage: (data) => {
                const page = doc.internal.getNumberOfPages();
                doc.setFontSize(8);
                doc.text(`${data.pageNumber} / ${page}`, pageWidth - 40, pageHeight - 20, { align: "right" });
            }
        });

        const safe = String(title || "export").replace(/[\\/:*?"<>|]/g, "_");
        doc.save(`${safe}.pdf`);
    };
})();
