# QUANTCONNECT.COM - Democratizing Finance, Empowering Individuals.
# Lean Algorithmic Trading Engine v2.0. Copyright 2014 QuantConnect Corporation.
#
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and

from AlgorithmImports import *

### <summary>
### Regression algorithm demonstrating the use of custom data sourced from the object store
### </summary>
class CustomDataObjectStoreRegressionAlgorithm(QCAlgorithm):
    CustomData = "2017-08-18 01:00:00,5749.5,5852.95,5749.5,5842.2,214402430,8753.33\r\n2017-08-18 02:00:00,5834.1,5904.35,5822.2,5898.85,144794030,5405.72\r\n2017-08-18 03:00:00,5885.5,5898.8,5852.3,5857.55,145721790,5163.09\r\n2017-08-18 04:00:00,5811.95,5815,5760.4,5770.9,160523863,5219.24\r\n2017-08-18 05:00:00,5794.75,5848.2,5786.05,5836.95,151929179,5429.87\r\n2017-08-18 06:00:00,5889.95,5900.45,5858.45,5867.9,123586417,4303.93\r\n2017-08-18 07:00:00,5833.15,5833.85,5775.55,5811.55,127624733,4823.52\r\n2017-08-18 08:00:00,5834.6,5864.95,5834.6,5859,110427867,4661.55\r\n2017-08-18 09:00:00,5869.9,5879.35,5802.85,5816.7,117516350,4820.53\r\n2017-08-18 10:00:00,5894.5,5948.85,5887.95,5935.1,120195681,4882.29\r\n2017-08-18 11:00:00,6000.5,6019,5951.15,6009,127707078,6591.27\r\n2017-08-18 12:00:00,5991.2,6038.2,5980.95,6030.8,116275729,4641.97\r\n2017-08-18 13:00:00,5930.8,5966.05,5910.95,5955.25,151162819,5915.8\r\n2017-08-18 14:00:00,5972.25,5989.8,5926.75,5973.3,191516153,8349.59\r\n2017-08-18 15:00:00,5984.7,6051.1,5974.55,6038.05,171728134,7774.83\r\n2017-08-18 16:00:00,5894.5,5948.85,5887.95,5935.1,120195681,4882.29\r\n2017-08-18 17:00:00,6000.5,6019,5951.15,6009,127707078,6591.27\r\n2017-08-18 18:00:00,5991.2,6038.2,5980.95,6030.8,116275729,4641.97\r\n2017-08-18 19:00:00,5894.5,5948.85,5887.95,5935.1,120195681,4882.29\r\n2017-08-18 20:00:00,5895,5956.55,5869.5,5921.4,114174694,4961.54\r\n2017-08-18 21:00:00,5900.05,5972.7,5871.3,5881,118346364,4888.65\r\n2017-08-18 22:00:00,5907.9,5931.65,5857.4,5878,100130739,4304.75\r\n2017-08-18 23:00:00,5848.75,5868.05,5780.35,5788.8,180902123,6695.57\r\n2017-08-19 01:00:00,5771.75,5792.9,5738.6,5760.2,140394424,5894.04\r\n2017-08-19 02:00:00,5709.35,5729.85,5683.1,5699.1,142041404,5462.45\r\n2017-08-19 03:00:00,5748.95,5819.4,5739.4,5808.4,124410018,5121.33\r\n2017-08-19 04:00:00,5820.4,5854.9,5770.25,5850.05,107160887,4560.84\r\n2017-08-19 05:00:00,5841.9,5863.4,5804.3,5813.6,117541145,4591.91\r\n2017-08-19 06:00:00,5805.75,5828.4,5777.9,5822.25,115539008,4643.17\r\n2017-08-19 07:00:00,5754.15,5755,5645.65,5655.9,198400131,7148\r\n2017-08-19 08:00:00,5639.9,5686.15,5616.85,5667.65,182410583,6697.18\r\n2017-08-19 09:00:00,5638.05,5640,5566.25,5590.25,193488581,6308.88\r\n2017-08-19 10:00:00,5606.95,5666.25,5570.25,5609.1,196571543,6792.49\r\n2017-08-19 11:00:00,5627.95,5635.25,5579.35,5588.7,160095940,5939.3\r\n2017-08-19 12:00:00,5647.95,5699.35,5630.95,5682.35,239029425,9184.29\r\n2017-08-19 13:00:00,5749.5,5852.95,5749.5,5842.2,214402430,8753.33\r\n2017-08-19 14:00:00,5834.1,5904.35,5822.2,5898.85,144794030,5405.72\r\n2017-08-19 15:00:00,5885.5,5898.8,5852.3,5857.55,145721790,5163.09\r\n2017-08-19 16:00:00,5811.95,5815,5760.4,5770.9,160523863,5219.24\r\n2017-08-19 17:00:00,5794.75,5848.2,5786.05,5836.95,151929179,5429.87\r\n2017-08-19 18:00:00,5889.95,5900.45,5858.45,5867.9,123586417,4303.93\r\n2017-08-19 19:00:00,5833.15,5833.85,5775.55,5811.55,127624733,4823.52\r\n2017-08-19 20:00:00,5834.6,5864.95,5834.6,5859,110427867,4661.55\r\n2017-08-19 21:00:00,5869.9,5879.35,5802.85,5816.7,117516350,4820.53\r\n2017-08-19 22:00:00,5894.5,5948.85,5887.95,5935.1,120195681,4882.29\r\n2017-08-19 23:00:00,6000.5,6019,5951.15,6009,127707078,6591.27\r\n2017-08-21 01:00:00,5749.5,5852.95,5749.5,5842.2,214402430,8753.33\r\n2017-08-21 02:00:00,5834.1,5904.35,5822.2,5898.85,144794030,5405.72\r\n2017-08-21 03:00:00,5885.5,5898.8,5852.3,5857.55,145721790,5163.09\r\n2017-08-21 04:00:00,5811.95,5815,5760.4,5770.9,160523863,5219.24\r\n2017-08-21 05:00:00,5794.75,5848.2,5786.05,5836.95,151929179,5429.87\r\n2017-08-21 06:00:00,5889.95,5900.45,5858.45,5867.9,123586417,4303.93\r\n2017-08-21 07:00:00,5833.15,5833.85,5775.55,5811.55,127624733,4823.52\r\n2017-08-21 08:00:00,5834.6,5864.95,5834.6,5859,110427867,4661.55\r\n2017-08-21 09:00:00,5869.9,5879.35,5802.85,5816.7,117516350,4820.53\r\n2017-08-21 10:00:00,5894.5,5948.85,5887.95,5935.1,120195681,4882.29\r\n2017-08-21 11:00:00,6000.5,6019,5951.15,6009,127707078,6591.27\r\n2017-08-21 12:00:00,5991.2,6038.2,5980.95,6030.8,116275729,4641.97\r\n2017-08-21 13:00:00,5930.8,5966.05,5910.95,5955.25,151162819,5915.8\r\n2017-08-21 14:00:00,5972.25,5989.8,5926.75,5973.3,191516153,8349.59\r\n2017-08-21 15:00:00,5984.7,6051.1,5974.55,6038.05,171728134,7774.83\r\n2017-08-21 16:00:00,5894.5,5948.85,5887.95,5935.1,120195681,4882.29\r\n2017-08-21 17:00:00,6000.5,6019,5951.15,6009,127707078,6591.27\r\n2017-08-21 18:00:00,5991.2,6038.2,5980.95,6030.8,116275729,4641.97\r\n2017-08-21 19:00:00,5894.5,5948.85,5887.95,5935.1,120195681,4882.29\r\n2017-08-21 20:00:00,5895,5956.55,5869.5,5921.4,114174694,4961.54\r\n2017-08-21 21:00:00,5900.05,5972.7,5871.3,5881,118346364,4888.65\r\n2017-08-21 22:00:00,5907.9,5931.65,5857.4,5878,100130739,4304.75\r\n2017-08-21 23:00:00,5848.75,5868.05,5780.35,5788.8,180902123,6695.57"

    def Initialize(self):
        self.SetStartDate(2017, 8, 18)
        self.SetEndDate(2017, 8, 21)
        self.SetCash(100000)

        ExampleCustomData.CustomDataKey = self.GetCustomDataKey()

        self.customSymbol = self.AddData(ExampleCustomData, "ExampleCustomData", Resolution.Hour).Symbol

        # Saving data here for demonstration and regression testing purposes.
        # In real scenarios, data has to be saved to the object store before the algorithm starts.
        self.SaveDataToObjectStore()

        self.receivedData = []

    def OnData(self, slice: Slice):
        if slice.ContainsKey(self.customSymbol):
            customData = slice.Get(ExampleCustomData, self.customSymbol)
            if customData.Price == 0:
                raise Exception("Custom data price was not expected to be zero")

            self.receivedData.append(customData)

    def OnEndOfAlgorithm(self):
        if not self.receivedData:
            raise Exception("Custom data was not fetched")

        customSecurity = self.Securities[self.customSymbol]
        if customSecurity is None or customSecurity.Price == 0:
            Exception("Expected the custom security to be added to the algorithm securities and to have a price that is not zero")

        # Make sure history requests work as expected
        history = self.History(ExampleCustomData, self.customSymbol, self.StartDate, self.EndDate, Resolution.Hour)

        if history.shape[0] != len(self.receivedData):
            raise Exception("History request returned more or less data than expected")

        for i in range(len(self.receivedData)):
            receivedData = self.receivedData[i]
            if (history.index[i][0] != receivedData.Symbol or
                history.index[i][1] != receivedData.Time or
                history[["value"]].values[i][0] != receivedData.Value or
                history[["open"]].values[i][0] != receivedData.Open or
                history[["high"]].values[i][0] != receivedData.High or
                history[["low"]].values[i][0] != receivedData.Low or
                history[["close"]].values[i][0] != receivedData.Close):
                raise Exception("History request returned different data than expected")

    def GetCustomDataKey(self):
        return "CustomData/ExampleCustomData"

    def SaveDataToObjectStore(self):
        self.ObjectStore.Save(self.GetCustomDataKey(), self.CustomData)

class ExampleCustomData(PythonData):
    CustomDataKey = ""

    def GetSource(self, config, date, isLive):
        return SubscriptionDataSource(self.CustomDataKey, SubscriptionTransportMedium.ObjectStore, FileFormat.Csv)

    def Reader(self, config, line, date, isLive):
        data = line.split(',')
        obj_data = ExampleCustomData()
        obj_data.Symbol = config.Symbol
        obj_data.Time = datetime.strptime(data[0], '%Y-%m-%d %H:%M:%S') + timedelta(hours=20)
        obj_data.Value = float(data[4])
        obj_data["Open"] = float(data[1])
        obj_data["High"] = float(data[2])
        obj_data["Low"] = float(data[3])
        obj_data["Close"] = float(data[4])
        return obj_data
