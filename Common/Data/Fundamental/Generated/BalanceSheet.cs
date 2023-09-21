/*
 * QUANTCONNECT.COM - Democratizing Finance, Empowering Individuals.
 * Lean Algorithmic Trading Engine v2.0. Copyright 2023 QuantConnect Corporation.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
*/

using System;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using QuantConnect.Data.UniverseSelection;

namespace QuantConnect.Data.Fundamental
{
    /// <summary>
    /// Definition of the BalanceSheet class
    /// </summary>
    public readonly struct BalanceSheet
    {
        /// <summary>
        /// Filing date of the Balance Sheet
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23542
        /// </remarks>
        [JsonProperty("23542")]
        public DateTime BSFileDate => FundamentalService.Get<DateTime>(_time, _securityIdentifier, "FinancialStatements.BalanceSheet.BSFileDate");

        /// <summary>
        /// Any money that a company owes its suppliers for goods and services purchased on credit and is expected to pay within the next year or operating cycle.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23000
        /// </remarks>
        [JsonProperty("23000")]
        public AccountsPayableBalanceSheet AccountsPayable => new(_time, _securityIdentifier);

        /// <summary>
        /// Accounts owed to a company by customers within a year as a result of exchanging goods or services on credit.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23001
        /// </remarks>
        [JsonProperty("23001")]
        public AccountsReceivableBalanceSheet AccountsReceivable => new(_time, _securityIdentifier);

        /// <summary>
        /// An expense recognized before it is paid for. Includes compensation, interest, pensions and all other miscellaneous accruals reported by the company. Expenses incurred during the accounting period, but not required to be paid until a later date.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23004
        /// </remarks>
        [JsonProperty("23004")]
        public CurrentAccruedExpensesBalanceSheet CurrentAccruedExpenses => new(_time, _securityIdentifier);

        /// <summary>
        /// An expense that has occurred but the transaction has not been entered in the accounting records. Accordingly, an adjusting entry is made to debit the appropriate expense account and to credit a liability account such as accrued expenses payable or accounts payable.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23005
        /// </remarks>
        [JsonProperty("23005")]
        public NonCurrentAccruedExpensesBalanceSheet NonCurrentAccruedExpenses => new(_time, _securityIdentifier);

        /// <summary>
        /// Interest, dividends, rents, ancillary and other revenues earned but not yet received by the entity on its investments.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23007
        /// </remarks>
        [JsonProperty("23007")]
        public AccruedInvestmentIncomeBalanceSheet AccruedInvestmentIncome => new(_time, _securityIdentifier);

        /// <summary>
        /// The cumulative amount of wear and tear or obsolescence charged against the fixed assets of a company.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23008
        /// </remarks>
        [JsonProperty("23008")]
        public AccumulatedDepreciationBalanceSheet AccumulatedDepreciation => new(_time, _securityIdentifier);

        /// <summary>
        /// The aggregate amount of gains or losses that are not part of retained earnings. It is also called other comprehensive income.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23009
        /// </remarks>
        [JsonProperty("23009")]
        public GainsLossesNotAffectingRetainedEarningsBalanceSheet GainsLossesNotAffectingRetainedEarnings => new(_time, _securityIdentifier);

        /// <summary>
        /// Excess of issue price over par or stated value of the entity's capital stock and amounts received from other transactions involving the entity's stock or stockholders. Includes adjustments to additional paid in capital. There are two major categories of additional paid in capital: 1) Paid in capital in excess of par/stated value, which is the difference between the actual issue price of the shares and the shares' par/stated value. 2) Paid in capital from other transactions which includes treasury stock, retirement of stock, stock dividends recorded at market, lapse of stock purchase warrants, conversion of convertible bonds in excess of the par value of the stock, and any other additional capital from the company's own stock transactions.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23012
        /// </remarks>
        [JsonProperty("23012")]
        public AdditionalPaidInCapitalBalanceSheet AdditionalPaidInCapital => new(_time, _securityIdentifier);

        /// <summary>
        /// A contra account sets aside as an allowance for bad loans (e.g. customer defaults).
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23016
        /// </remarks>
        [JsonProperty("23016")]
        public AllowanceForLoansAndLeaseLossesBalanceSheet AllowanceForLoansAndLeaseLosses => new(_time, _securityIdentifier);

        /// <summary>
        /// For an unclassified balance sheet, this item represents equity securities categorized neither as held-to-maturity nor trading. Equity securities represent ownership interests or the right to acquire ownership interests in corporations and other legal entities which ownership interest is represented by shares of common or preferred stock (which is not mandatory redeemable or redeemable at the option of the holder), convertible securities, stock rights, or stock warrants. This category includes preferred stocks, available- for-sale and common stock, available-for-sale.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23020
        /// </remarks>
        [JsonProperty("23020")]
        public AvailableForSaleSecuritiesBalanceSheet AvailableForSaleSecurities => new(_time, _securityIdentifier);

        /// <summary>
        /// The total amount of stock authorized for issue by a corporation, including common and preferred stock.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23027
        /// </remarks>
        [JsonProperty("23027")]
        public CapitalStockBalanceSheet CapitalStock => new(_time, _securityIdentifier);

        /// <summary>
        /// Cash includes currency on hand as well as demand deposits with banks or financial institutions. It also includes other kinds of accounts that have the general characteristics of demand deposits in that the customer may deposit additional funds at any time and also effectively may withdraw funds at any time without prior notice or penalty.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23028
        /// </remarks>
        [JsonProperty("23028")]
        public CashBalanceSheet Cash => new(_time, _securityIdentifier);

        /// <summary>
        /// Cash equivalents, excluding items classified as marketable securities, include short-term, highly liquid investments that are both readily convertible to known amounts of cash, and so near their maturity that they present insignificant risk of changes in value because of changes in interest rates. Generally, only investments with original maturities of three months or less qualify under this definition. Original maturity means original maturity to the entity holding the investment. For example, both a three-month US Treasury bill and a three-year Treasury note purchased three months from maturity qualify as cash equivalents. However, a Treasury note purchased three years ago does not become a cash equivalent when its remaining maturity is three months.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23029
        /// </remarks>
        [JsonProperty("23029")]
        public CashEquivalentsBalanceSheet CashEquivalents => new(_time, _securityIdentifier);

        /// <summary>
        /// Includes unrestricted cash on hand, money market instruments and other debt securities which can be converted to cash immediately.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23030
        /// </remarks>
        [JsonProperty("23030")]
        public CashAndCashEquivalentsBalanceSheet CashAndCashEquivalents => new(_time, _securityIdentifier);

        /// <summary>
        /// Includes cash on hand (currency and coin), cash items in process of collection, non-interest bearing deposits due from other financial institutions (including corporate credit unions), and balances with the Federal Reserve Banks, Federal Home Loan Banks and central banks.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23031
        /// </remarks>
        [JsonProperty("23031")]
        public CashAndDueFromBanksBalanceSheet CashAndDueFromBanks => new(_time, _securityIdentifier);

        /// <summary>
        /// The aggregate amount of cash, cash equivalents, and federal funds sold.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23032
        /// </remarks>
        [JsonProperty("23032")]
        public CashCashEquivalentsAndFederalFundsSoldBalanceSheet CashCashEquivalentsAndFederalFundsSold => new(_time, _securityIdentifier);

        /// <summary>
        /// The aggregate amount of cash, cash equivalents, and marketable securities.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23033
        /// </remarks>
        [JsonProperty("23033")]
        public CashCashEquivalentsAndMarketableSecuritiesBalanceSheet CashCashEquivalentsAndMarketableSecurities => new(_time, _securityIdentifier);

        /// <summary>
        /// Common stock (all issues) at par value, as reported within the Stockholder's Equity section of the balance sheet; i.e. it is one component of Common Stockholder's Equity
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23038
        /// </remarks>
        [JsonProperty("23038")]
        public CommonStockBalanceSheet CommonStock => new(_time, _securityIdentifier);

        /// <summary>
        /// The total amount of assets considered to be convertible into cash within a relatively short period of time, usually a year.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23044
        /// </remarks>
        [JsonProperty("23044")]
        public CurrentAssetsBalanceSheet CurrentAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// Represents the total amount of long-term debt such as bank loans and commercial paper, which is due within one year.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23045
        /// </remarks>
        [JsonProperty("23045")]
        public CurrentDebtBalanceSheet CurrentDebt => new(_time, _securityIdentifier);

        /// <summary>
        /// All borrowings due within one year including current portions of long-term debt and capital leases as well as short-term debt such as bank loans and commercial paper.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23046
        /// </remarks>
        [JsonProperty("23046")]
        public CurrentDebtAndCapitalLeaseObligationBalanceSheet CurrentDebtAndCapitalLeaseObligation => new(_time, _securityIdentifier);

        /// <summary>
        /// The debts or obligations of the firm that are due within one year.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23047
        /// </remarks>
        [JsonProperty("23047")]
        public CurrentLiabilitiesBalanceSheet CurrentLiabilities => new(_time, _securityIdentifier);

        /// <summary>
        /// Represents the total amount of long-term capital leases that must be paid within the next accounting period. Capital lease obligations are contractual obligations that arise from obtaining the use of property or equipment via a capital lease contract.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23048
        /// </remarks>
        [JsonProperty("23048")]
        public CurrentCapitalLeaseObligationBalanceSheet CurrentCapitalLeaseObligation => new(_time, _securityIdentifier);

        /// <summary>
        /// An amount owed to a firm that is not expected to be received by the firm within one year from the date of the balance sheet.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23052
        /// </remarks>
        [JsonProperty("23052")]
        public DeferredAssetsBalanceSheet DeferredAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// An expenditure not recognized as a cost of operation of the period in which incurred, but carried forward to be written off in future periods.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23054
        /// </remarks>
        [JsonProperty("23054")]
        public DeferredCostsBalanceSheet DeferredCosts => new(_time, _securityIdentifier);

        /// <summary>
        /// Represents the non-current portion of obligations, which is a liability that usually would have been paid but is now past due.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23057
        /// </remarks>
        [JsonProperty("23057")]
        public NonCurrentDeferredLiabilitiesBalanceSheet NonCurrentDeferredLiabilities => new(_time, _securityIdentifier);

        /// <summary>
        /// Represents the current portion of obligations, which is a liability that usually would have been paid but is now past due.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23058
        /// </remarks>
        [JsonProperty("23058")]
        public CurrentDeferredLiabilitiesBalanceSheet CurrentDeferredLiabilities => new(_time, _securityIdentifier);

        /// <summary>
        /// Net amount of deferred policy acquisition costs capitalized on contracts remaining in force as of the balance sheet date.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23059
        /// </remarks>
        [JsonProperty("23059")]
        public DeferredPolicyAcquisitionCostsBalanceSheet DeferredPolicyAcquisitionCosts => new(_time, _securityIdentifier);

        /// <summary>
        /// Represents collections of cash or other assets related to revenue producing activity for which revenue has not yet been recognized. Generally, an entity records deferred revenue when it receives consideration from a customer before achieving certain criteria that must be met for revenue to be recognized in conformity with GAAP. It can be either current or non-current item. Also called unearned revenue.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23061
        /// </remarks>
        [JsonProperty("23061")]
        public CurrentDeferredRevenueBalanceSheet CurrentDeferredRevenue => new(_time, _securityIdentifier);

        /// <summary>
        /// The non-current portion of deferred revenue amount as of the balance sheet date. Deferred revenue is a liability related to revenue producing activity for which revenue has not yet been recognized, and is not expected be recognized in the next twelve months.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23062
        /// </remarks>
        [JsonProperty("23062")]
        public NonCurrentDeferredRevenueBalanceSheet NonCurrentDeferredRevenue => new(_time, _securityIdentifier);

        /// <summary>
        /// An asset on a company's balance sheet that may be used to reduce any subsequent period's income tax expense. Deferred tax assets can arise due to net loss carryovers, which are only recorded as assets if it is deemed more likely than not that the asset will be used in future fiscal periods.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23063
        /// </remarks>
        [JsonProperty("23063")]
        public DeferredTaxAssetsBalanceSheet DeferredTaxAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// Meaning a future tax asset, resulting from temporary differences between book (accounting) value of assets and liabilities and their tax value, or timing differences between the recognition of gains and losses in financial statements and their recognition in a tax computation. It is also called future tax.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23064
        /// </remarks>
        [JsonProperty("23064")]
        public CurrentDeferredTaxesAssetsBalanceSheet CurrentDeferredTaxesAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// Meaning a future tax liability, resulting from temporary differences between book (accounting) value of assets and liabilities and their tax value, or timing differences between the recognition of gains and losses in financial statements and their recognition in a tax computation. Deferred tax liabilities generally arise where tax relief is provided in advance of an accounting expense, or income is accrued but not taxed until received.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23065
        /// </remarks>
        [JsonProperty("23065")]
        public CurrentDeferredTaxesLiabilitiesBalanceSheet CurrentDeferredTaxesLiabilities => new(_time, _securityIdentifier);

        /// <summary>
        /// A result of timing differences between taxable incomes reported on the income statement and taxable income from the company's tax return. Depending on the positioning of deferred income taxes, the field may be either current (within current assets) or non- current (below total current assets). Typically a company will have two deferred income taxes fields.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23066
        /// </remarks>
        [JsonProperty("23066")]
        public NonCurrentDeferredTaxesAssetsBalanceSheet NonCurrentDeferredTaxesAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// The estimated future tax obligations, which usually arise when different accounting methods are used for financial statements and tax statement It is also an add-back to the cash flow statement. Deferred income taxes include accumulated tax deferrals due to accelerated depreciation and investment credit.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23067
        /// </remarks>
        [JsonProperty("23067")]
        public NonCurrentDeferredTaxesLiabilitiesBalanceSheet NonCurrentDeferredTaxesLiabilities => new(_time, _securityIdentifier);

        /// <summary>
        /// This asset represents equity securities categorized neither as held-to-maturity nor trading.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23076
        /// </remarks>
        [JsonProperty("23076")]
        public EquityInvestmentsBalanceSheet EquityInvestments => new(_time, _securityIdentifier);

        /// <summary>
        /// This liability refers to the amount shown on the books that a bank with insufficient reserves borrows, at the federal funds rate, from another bank to meet its reserve requirements; and the amount of securities that an institution sells and agrees to repurchase at a specified date for a specified price, net of any reductions or offsets.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23079
        /// </remarks>
        [JsonProperty("23079")]
        public FederalFundsPurchasedAndSecuritiesSoldUnderAgreementToRepurchaseBalanceSheet FederalFundsPurchasedAndSecuritiesSoldUnderAgreementToRepurchase => new(_time, _securityIdentifier);

        /// <summary>
        /// This asset refers to very-short-term loans of funds to other banks and securities dealers.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23081
        /// </remarks>
        [JsonProperty("23081")]
        public FederalFundsSoldAndSecuritiesPurchaseUnderAgreementsToResellBalanceSheet FederalFundsSoldAndSecuritiesPurchaseUnderAgreementsToResell => new(_time, _securityIdentifier);

        /// <summary>
        /// This asset refers to types of investments that may be contained within the fixed maturity category which securities are having a stated final repayment date. Examples of items within this category may include bonds, including convertibles and bonds with warrants, and redeemable preferred stocks.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23089
        /// </remarks>
        [JsonProperty("23089")]
        public FixedMaturityInvestmentsBalanceSheet FixedMaturityInvestments => new(_time, _securityIdentifier);

        /// <summary>
        /// Accounting policy pertaining to an insurance entity's net liability for future benefits (for example, death, cash surrender value) to be paid to or on behalf of policyholders, describing the bases, methodologies and components of the reserve, and assumptions regarding estimates of expected investment yields, mortality, morbidity, terminations and expenses.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23095
        /// </remarks>
        [JsonProperty("23095")]
        public FuturePolicyBenefitsBalanceSheet FuturePolicyBenefits => new(_time, _securityIdentifier);

        /// <summary>
        /// In a limited partnership or master limited partnership form of business, this represents the balance of capital held by the general partners.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23096
        /// </remarks>
        [JsonProperty("23096")]
        public GeneralPartnershipCapitalBalanceSheet GeneralPartnershipCapital => new(_time, _securityIdentifier);

        /// <summary>
        /// The excess of the cost of an acquired company over the sum of the fair market value of its identifiable individual assets less the liabilities.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23097
        /// </remarks>
        [JsonProperty("23097")]
        public GoodwillBalanceSheet Goodwill => new(_time, _securityIdentifier);

        /// <summary>
        /// Rights or economic benefits, such as patents and goodwill, that is not physical in nature. They are those that are neither physical nor financial in nature, nevertheless, have value to the company. Intangibles are listed net of accumulated amortization.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23098
        /// </remarks>
        [JsonProperty("23098")]
        public GoodwillAndOtherIntangibleAssetsBalanceSheet GoodwillAndOtherIntangibleAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// Represents the sum of all loans (commercial, consumer, mortgage, etc.) as well as leases before any provisions for loan losses or unearned discounts.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23099
        /// </remarks>
        [JsonProperty("23099")]
        public GrossLoanBalanceSheet GrossLoan => new(_time, _securityIdentifier);

        /// <summary>
        /// Carrying amount at the balance sheet date for long-lived physical assets used in the normal conduct of business and not intended for resale. This can include land, physical structures, machinery, vehicles, furniture, computer equipment, construction in progress, and similar items. Amount does not include depreciation.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23100
        /// </remarks>
        [JsonProperty("23100")]
        public GrossPPEBalanceSheet GrossPPE => new(_time, _securityIdentifier);

        /// <summary>
        /// Debt securities that a firm has the ability and intent to hold until maturity.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23102
        /// </remarks>
        [JsonProperty("23102")]
        public HeldToMaturitySecuritiesBalanceSheet HeldToMaturitySecurities => new(_time, _securityIdentifier);

        /// <summary>
        /// A current liability account which reflects the amount of income taxes currently due to the federal, state, and local governments.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23103
        /// </remarks>
        [JsonProperty("23103")]
        public IncomeTaxPayableBalanceSheet IncomeTaxPayable => new(_time, _securityIdentifier);

        /// <summary>
        /// The aggregate of all domestic and foreign deposits in the bank that earns interests.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23105
        /// </remarks>
        [JsonProperty("23105")]
        public InterestBearingDepositsLiabilitiesBalanceSheet InterestBearingDepositsLiabilities => new(_time, _securityIdentifier);

        /// <summary>
        /// Sum of the carrying values as of the balance sheet date of interest payable on all forms of debt, including trade payable that has been incurred.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23106
        /// </remarks>
        [JsonProperty("23106")]
        public InterestPayableBalanceSheet InterestPayable => new(_time, _securityIdentifier);

        /// <summary>
        /// Deposit of money with a financial institution, in consideration of which the financial institution pays or credits interest, or amounts in the nature of interest.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23107
        /// </remarks>
        [JsonProperty("23107")]
        public InterestBearingDepositsAssetsBalanceSheet InterestBearingDepositsAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// A company's merchandise, raw materials, and finished and unfinished products which have not yet been sold.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23108
        /// </remarks>
        [JsonProperty("23108")]
        public InventoryBalanceSheet Inventory => new(_time, _securityIdentifier);

        /// <summary>
        /// All investments in affiliates, real estate, securities, etc. Non-current investment, not including marketable securities.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23111
        /// </remarks>
        [JsonProperty("23111")]
        public InvestmentsAndAdvancesBalanceSheet InvestmentsAndAdvances => new(_time, _securityIdentifier);

        /// <summary>
        /// In a limited partnership or master limited partnership form of business, this represents the balance of capital held by the limited partners.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23118
        /// </remarks>
        [JsonProperty("23118")]
        public LimitedPartnershipCapitalBalanceSheet LimitedPartnershipCapital => new(_time, _securityIdentifier);

        /// <summary>
        /// Sum of the carrying values as of the balance sheet date of all long-term debt, which is debt initially having maturities due after one year or beyond the operating cycle, if longer, but excluding the portions thereof scheduled to be repaid within one year or the normal operating cycle, if longer. Long-term debt includes notes payable, bonds payable, mortgage loans, convertible debt, subordinated debt and other types of long term debt.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23123
        /// </remarks>
        [JsonProperty("23123")]
        public LongTermDebtBalanceSheet LongTermDebt => new(_time, _securityIdentifier);

        /// <summary>
        /// All borrowings lasting over one year including long-term debt and long-term portion of capital lease obligations.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23124
        /// </remarks>
        [JsonProperty("23124")]
        public LongTermDebtAndCapitalLeaseObligationBalanceSheet LongTermDebtAndCapitalLeaseObligation => new(_time, _securityIdentifier);

        /// <summary>
        /// Often referred to simply as "investments". Long-term investments are to be held for many years and are not intended to be disposed in the near future. This group usually consists of four types of investments.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23126
        /// </remarks>
        [JsonProperty("23126")]
        public LongTermInvestmentsBalanceSheet LongTermInvestments => new(_time, _securityIdentifier);

        /// <summary>
        /// Represents the total liability for long-term leases lasting over one year. Amount equal to the present value (the principal) at the beginning of the lease term less lease payments during the lease term.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23127
        /// </remarks>
        [JsonProperty("23127")]
        public LongTermCapitalLeaseObligationBalanceSheet LongTermCapitalLeaseObligation => new(_time, _securityIdentifier);

        /// <summary>
        /// Carrying amount of the equity interests owned by non-controlling shareholders, partners, or other equity holders in one or more of the entities included in the reporting entity's consolidated financial statements.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23132
        /// </remarks>
        [JsonProperty("23132")]
        public MinorityInterestBalanceSheet MinorityInterest => new(_time, _securityIdentifier);

        /// <summary>
        /// Short-term (typical maturity is less than one year), highly liquid government or corporate debt instrument such as bankers' acceptance, promissory notes, and treasury bills.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23133
        /// </remarks>
        [JsonProperty("23133")]
        public MoneyMarketInvestmentsBalanceSheet MoneyMarketInvestments => new(_time, _securityIdentifier);

        /// <summary>
        /// Represents the value of all loans after deduction of the appropriate allowances for loan and lease losses.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23137
        /// </remarks>
        [JsonProperty("23137")]
        public NetLoanBalanceSheet NetLoan => new(_time, _securityIdentifier);

        /// <summary>
        /// Tangible assets that are held by an entity for use in the production or supply of goods and services, for rental to others, or for administrative purposes and that are expected to provide economic benefit for more than one year; net of accumulated depreciation.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23139
        /// </remarks>
        [JsonProperty("23139")]
        public NetPPEBalanceSheet NetPPE => new(_time, _securityIdentifier);

        /// <summary>
        /// The aggregate amount of all domestic and foreign deposits in the banks that do not draw interest.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23142
        /// </remarks>
        [JsonProperty("23142")]
        public NonInterestBearingDepositsBalanceSheet NonInterestBearingDeposits => new(_time, _securityIdentifier);

        /// <summary>
        /// Written promises to pay a stated sum at one or more specified dates in the future, within the accounting period.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23143
        /// </remarks>
        [JsonProperty("23143")]
        public CurrentNotesPayableBalanceSheet CurrentNotesPayable => new(_time, _securityIdentifier);

        /// <summary>
        /// An amount representing an agreement for an unconditional promise by the maker to pay the entity (holder) a definite sum of money at a future date(s) within one year of the balance sheet date or the normal operating cycle, whichever is longer. Such amount may include accrued interest receivable in accordance with the terms of the note. The note also may contain provisions including a discount or premium, payable on demand, secured, or unsecured, interest bearing or non-interest bearing, among a myriad of other features and characteristics.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23144
        /// </remarks>
        [JsonProperty("23144")]
        public NotesReceivableBalanceSheet NotesReceivable => new(_time, _securityIdentifier);

        /// <summary>
        /// An amount representing an agreement for an unconditional promise by the maker to pay the entity (holder) a definite sum of money at a future date(s), excluding the portion that is expected to be received within one year of the balance sheet date or the normal operating cycle, whichever is longer.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23146
        /// </remarks>
        [JsonProperty("23146")]
        public NonCurrentNoteReceivablesBalanceSheet NonCurrentNoteReceivables => new(_time, _securityIdentifier);

        /// <summary>
        /// Other current liabilities = Total current liabilities - Payables and accrued Expenses - Current debt and capital lease obligation - provisions, current - deferred liabilities, current.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23151
        /// </remarks>
        [JsonProperty("23151")]
        public OtherCurrentLiabilitiesBalanceSheet OtherCurrentLiabilities => new(_time, _securityIdentifier);

        /// <summary>
        /// Sum of the carrying amounts of all intangible assets, excluding goodwill.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23155
        /// </remarks>
        [JsonProperty("23155")]
        public OtherIntangibleAssetsBalanceSheet OtherIntangibleAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// The aggregate amount of short term investments, which will be expired within one year that are not specifically classified as Available-for-Sale, Held-to-Maturity, nor Trading investments.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23163
        /// </remarks>
        [JsonProperty("23163")]
        public OtherShortTermInvestmentsBalanceSheet OtherShortTermInvestments => new(_time, _securityIdentifier);

        /// <summary>
        /// The sum of all payables owed and expected to be paid within one year or one operating cycle, including accounts payables, taxes payable, dividends payable and all other current payables.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23165
        /// </remarks>
        [JsonProperty("23165")]
        public PayablesBalanceSheet Payables => new(_time, _securityIdentifier);

        /// <summary>
        /// This balance sheet account includes all current payables and accrued expenses.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23166
        /// </remarks>
        [JsonProperty("23166")]
        public PayablesAndAccruedExpensesBalanceSheet PayablesAndAccruedExpenses => new(_time, _securityIdentifier);

        /// <summary>
        /// Accounting policy pertaining to an insurance entity's net liability for future benefits (for example, death, cash surrender value) to be paid to or on behalf of policyholders, describing the bases, methodologies and components of the reserve, and assumptions regarding estimates of expected investment yields, mortality, morbidity, terminations and expenses.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23169
        /// </remarks>
        [JsonProperty("23169")]
        public PolicyReservesBenefitsBalanceSheet PolicyReservesBenefits => new(_time, _securityIdentifier);

        /// <summary>
        /// The total liability as of the balance sheet date of amounts due to policy holders, excluding future policy benefits and claims, including unpaid policy dividends, retrospective refunds, and undistributed earnings on participating business.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23171
        /// </remarks>
        [JsonProperty("23171")]
        public PolicyholderFundsBalanceSheet PolicyholderFunds => new(_time, _securityIdentifier);

        /// <summary>
        /// Preferred securities that that firm treats as a liability. It includes convertible preferred stock or redeemable preferred stock.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23172
        /// </remarks>
        [JsonProperty("23172")]
        public PreferredSecuritiesOutsideStockEquityBalanceSheet PreferredSecuritiesOutsideStockEquity => new(_time, _securityIdentifier);

        /// <summary>
        /// Preferred stock (all issues) at par value, as reported within the Stockholder's Equity section of the balance sheet.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23174
        /// </remarks>
        [JsonProperty("23174")]
        public PreferredStockBalanceSheet PreferredStock => new(_time, _securityIdentifier);

        /// <summary>
        /// Sum of the carrying amounts that are paid in advance for expenses, which will be charged against earnings in subsequent periods.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23179
        /// </remarks>
        [JsonProperty("23179")]
        public PrepaidAssetsBalanceSheet PrepaidAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// Sum of the carrying amounts that are paid in advance for expenses, which will be charged against earnings in periods after one year or beyond the operating cycle, if longer.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23180
        /// </remarks>
        [JsonProperty("23180")]
        public NonCurrentPrepaidAssetsBalanceSheet NonCurrentPrepaidAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// The sum of all receivables owed by customers and affiliates within one year, including accounts receivable, notes receivable, premiums receivable, and other current receivables.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23189
        /// </remarks>
        [JsonProperty("23189")]
        public ReceivablesBalanceSheet Receivables => new(_time, _securityIdentifier);

        /// <summary>
        /// The amount of benefits the ceding insurer expects to recover on insurance policies ceded to other insurance entities as of the balance sheet date for all guaranteed benefit types. It includes estimated amounts for claims incurred but not reported, and policy benefits, net of any related valuation allowance.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23196
        /// </remarks>
        [JsonProperty("23196")]
        public ReinsuranceRecoverableBalanceSheet ReinsuranceRecoverable => new(_time, _securityIdentifier);

        /// <summary>
        /// The cumulative net income of the company from the date of its inception (or reorganization) to the date of the financial statement less the cumulative distributions to shareholders either directly (dividends) or indirectly (treasury stock).
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23204
        /// </remarks>
        [JsonProperty("23204")]
        public RetainedEarningsBalanceSheet RetainedEarnings => new(_time, _securityIdentifier);

        /// <summary>
        /// The carrying value as of the balance sheet date of the liabilities collateral securities loaned to other broker-dealers. Borrowers of securities generally are required to provide collateral to the lenders of securities, commonly cash but sometimes other securities or standby letters of credit, with a value slightly higher than that of the securities borrowed.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23205
        /// </remarks>
        [JsonProperty("23205")]
        public SecuritiesLendingCollateralBalanceSheet SecuritiesLendingCollateral => new(_time, _securityIdentifier);

        /// <summary>
        /// The carrying value of funds outstanding loaned in the form of security resale agreements if the agreement requires the purchaser to resell the identical security purchased or a security that meets the definition of "substantially the same" in the case of a dollar roll. Also includes purchases of participations in pools of securities that are subject to a resale agreement.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23207
        /// </remarks>
        [JsonProperty("23207")]
        public SecurityAgreeToBeResellBalanceSheet SecurityAgreeToBeResell => new(_time, _securityIdentifier);

        /// <summary>
        /// Represent obligations of the company to deliver the specified security at the contracted price and, thereby, create a liability to purchase the security in the market at prevailing prices.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23208
        /// </remarks>
        [JsonProperty("23208")]
        public SecuritySoldNotYetRepurchasedBalanceSheet SecuritySoldNotYetRepurchased => new(_time, _securityIdentifier);

        /// <summary>
        /// The fair value of the assets held by the company for the benefit of separate account policyholders.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23209
        /// </remarks>
        [JsonProperty("23209")]
        public SeparateAccountAssetsBalanceSheet SeparateAccountAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// Refers to revenue that is generated that is not part of typical operations.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23210
        /// </remarks>
        [JsonProperty("23210")]
        public SeparateAccountBusinessBalanceSheet SeparateAccountBusiness => new(_time, _securityIdentifier);

        /// <summary>
        /// The current assets section of a company's balance sheet that contains the investments that a company holds with the purpose for trading.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23212
        /// </remarks>
        [JsonProperty("23212")]
        public ShortTermInvestmentsAvailableForSaleBalanceSheet ShortTermInvestmentsAvailableForSale => new(_time, _securityIdentifier);

        /// <summary>
        /// The current assets section of a company's balance sheet that contains the investments that a company has made that will expire at a fixed date within one year.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23213
        /// </remarks>
        [JsonProperty("23213")]
        public ShortTermInvestmentsHeldToMaturityBalanceSheet ShortTermInvestmentsHeldToMaturity => new(_time, _securityIdentifier);

        /// <summary>
        /// The current assets section of a company's balance sheet that contains the investments that a company can trade at any moment.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23214
        /// </remarks>
        [JsonProperty("23214")]
        public ShortTermInvestmentsTradingBalanceSheet ShortTermInvestmentsTrading => new(_time, _securityIdentifier);

        /// <summary>
        /// The residual interest in the assets of the enterprise that remains after deducting its liabilities. Equity is increased by owners' investments and by comprehensive income, and it is reduced by distributions to the owners.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23215
        /// </remarks>
        [JsonProperty("23215")]
        public StockholdersEquityBalanceSheet StockholdersEquity => new(_time, _securityIdentifier);

        /// <summary>
        /// A liability that reflects the taxes owed to federal, state, and local tax authorities. It is the carrying value as of the balance sheet date of obligations incurred and payable for statutory income, sales, use, payroll, excise, real, property and other taxes.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23217
        /// </remarks>
        [JsonProperty("23217")]
        public TotalTaxPayableBalanceSheet TotalTaxPayable => new(_time, _securityIdentifier);

        /// <summary>
        /// The aggregate amount of probable future economic benefits obtained or controlled by a particular enterprise as a result of past transactions or events.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23220
        /// </remarks>
        [JsonProperty("23220")]
        public TotalAssetsBalanceSheet TotalAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// A liability account which represents the total amount of funds deposited.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23223
        /// </remarks>
        [JsonProperty("23223")]
        public TotalDepositsBalanceSheet TotalDeposits => new(_time, _securityIdentifier);

        /// <summary>
        /// Asset that refers to the sum of all available for sale securities and other investments often reported on the balance sheet of insurance firms.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23224
        /// </remarks>
        [JsonProperty("23224")]
        public TotalInvestmentsBalanceSheet TotalInvestments => new(_time, _securityIdentifier);

        /// <summary>
        /// Sum of the carrying amounts as of the balance sheet date of all assets that are expected to be realized in cash, sold or consumed after one year or beyond the normal operating cycle, if longer.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23226
        /// </remarks>
        [JsonProperty("23226")]
        public TotalNonCurrentAssetsBalanceSheet TotalNonCurrentAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// Ownership interest of different classes of partners in the publicly listed limited partnership or master limited partnership. Partners include general, limited and preferred partners.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23228
        /// </remarks>
        [JsonProperty("23228")]
        public TotalPartnershipCapitalBalanceSheet TotalPartnershipCapital => new(_time, _securityIdentifier);

        /// <summary>
        /// Trading account assets are bought and held principally for the purpose of selling them in the near term (thus held for only a short period of time). Unrealized holding gains and losses for trading securities are included in earnings.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23229
        /// </remarks>
        [JsonProperty("23229")]
        public TradingAssetsBalanceSheet TradingAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// The carrying amount of liabilities as of the balance sheet date that pertain to principal and customer trading transactions, or which may be incurred with the objective of generating a profit from short-term fluctuations in price as part of an entity's market-making, hedging and proprietary trading. Examples include short positions in securities, derivatives and commodities, obligations under repurchase agreements, and securities borrowed arrangements.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23230
        /// </remarks>
        [JsonProperty("23230")]
        public TradingLiabilitiesBalanceSheet TradingLiabilities => new(_time, _securityIdentifier);

        /// <summary>
        /// The total of financial instruments that are bought and held principally for the purpose of selling them in the near term (thus held for only a short period of time) or for debt and equity securities formerly categorized as available-for-sale or held-to-maturity which the company held as of the date it opted to account for such securities at fair value.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23231
        /// </remarks>
        [JsonProperty("23231")]
        public TradingSecuritiesBalanceSheet TradingSecurities => new(_time, _securityIdentifier);

        /// <summary>
        /// The portion of shares that a company keeps in their own treasury. Treasury stock may have come from a repurchase or buyback from shareholders; or it may have never been issued to the public in the first place. These shares don't pay dividends, have no voting rights, and are not included in shares outstanding calculations.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23232
        /// </remarks>
        [JsonProperty("23232")]
        public TreasuryStockBalanceSheet TreasuryStock => new(_time, _securityIdentifier);

        /// <summary>
        /// Income received but not yet earned, it represents the unearned amount that is netted against the total loan.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23235
        /// </remarks>
        [JsonProperty("23235")]
        public UnearnedIncomeBalanceSheet UnearnedIncome => new(_time, _securityIdentifier);

        /// <summary>
        /// Carrying amount of premiums written on insurance contracts that have not been earned as of the balance sheet date.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23236
        /// </remarks>
        [JsonProperty("23236")]
        public UnearnedPremiumsBalanceSheet UnearnedPremiums => new(_time, _securityIdentifier);

        /// <summary>
        /// Liability amount that reflects claims that are expected based upon statistical projections, but which have not been reported to the insurer.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23237
        /// </remarks>
        [JsonProperty("23237")]
        public UnpaidLossAndLossReserveBalanceSheet UnpaidLossAndLossReserve => new(_time, _securityIdentifier);

        /// <summary>
        /// Invested capital = common shareholders' equity + long term debt + current debt
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23245
        /// </remarks>
        [JsonProperty("23245")]
        public InvestedCapitalBalanceSheet InvestedCapital => new(_time, _securityIdentifier);

        /// <summary>
        /// Payments that will be assigned as expenses with one accounting period, but that are paid in advance and temporarily set up as current assets on the balance sheet.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23252
        /// </remarks>
        [JsonProperty("23252")]
        public CurrentDeferredAssetsBalanceSheet CurrentDeferredAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// Payments that will be assigned as expenses longer than one accounting period, but that are paid in advance and temporarily set up as non-current assets on the balance sheet.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23253
        /// </remarks>
        [JsonProperty("23253")]
        public NonCurrentDeferredAssetsBalanceSheet NonCurrentDeferredAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// Asset, often applicable to Banks, which refers to the aggregate amount of all securities and investments.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23258
        /// </remarks>
        [JsonProperty("23258")]
        public SecuritiesAndInvestmentsBalanceSheet SecuritiesAndInvestments => new(_time, _securityIdentifier);

        /// <summary>
        /// Probable future sacrifices of economic benefits arising from present obligations of an enterprise to transfer assets or provide services to others in the future as a result of past transactions or events, excluding minority interest.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23259
        /// </remarks>
        [JsonProperty("23259")]
        public TotalLiabilitiesNetMinorityInterestBalanceSheet TotalLiabilitiesNetMinorityInterest => new(_time, _securityIdentifier);

        /// <summary>
        /// Total obligations, net minority interest, incurred as part of normal operations that is expected to be repaid beyond the following twelve months or one business cycle; excludes minority interest.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23260
        /// </remarks>
        [JsonProperty("23260")]
        public TotalNonCurrentLiabilitiesNetMinorityInterestBalanceSheet TotalNonCurrentLiabilitiesNetMinorityInterest => new(_time, _securityIdentifier);

        /// <summary>
        /// Residual interest, including minority interest, that remains in the assets of the enterprise after deducting its liabilities. Equity is increased by owners' investments and by comprehensive income, and it is reduced by distributions to the owners.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23261
        /// </remarks>
        [JsonProperty("23261")]
        public TotalEquityGrossMinorityInterestBalanceSheet TotalEquityGrossMinorityInterest => new(_time, _securityIdentifier);

        /// <summary>
        /// Accounts owed to a company by customers within a year as a result of exchanging goods or services on credit.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23262
        /// </remarks>
        [JsonProperty("23262")]
        public GrossAccountsReceivableBalanceSheet GrossAccountsReceivable => new(_time, _securityIdentifier);

        /// <summary>
        /// Accounts receivable represents sums owed to the business that the business records as revenue. Gross accounts receivable is accounts receivable before the business deducts uncollectable accounts to calculate the true value of accounts receivable.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23263
        /// </remarks>
        [JsonProperty("23263")]
        public NonCurrentAccountsReceivableBalanceSheet NonCurrentAccountsReceivable => new(_time, _securityIdentifier);

        /// <summary>
        /// This account shows the amount of unpaid interest accrued to the date of purchase and included in the purchase price of securities purchased between interest dates.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23264
        /// </remarks>
        [JsonProperty("23264")]
        public AccruedInterestReceivableBalanceSheet AccruedInterestReceivable => new(_time, _securityIdentifier);

        /// <summary>
        /// This item is typically available for bank industry. It's the amount of borrowings as of the balance sheet date from the Federal Home Loan Bank, which are primarily used to cover shortages in the required reserve balance and liquidity shortages.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23265
        /// </remarks>
        [JsonProperty("23265")]
        public AdvanceFromFederalHomeLoanBanksBalanceSheet AdvanceFromFederalHomeLoanBanks => new(_time, _securityIdentifier);

        /// <summary>
        /// An Allowance for Doubtful Accounts measures receivables recorded but not expected to be collected.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23266
        /// </remarks>
        [JsonProperty("23266")]
        public AllowanceForDoubtfulAccountsReceivableBalanceSheet AllowanceForDoubtfulAccountsReceivable => new(_time, _securityIdentifier);

        /// <summary>
        /// This item is typically available for bank industry. It represents a provision relating to a written agreement to receive money with the terms of the note (at a specified future date(s) within one year from the reporting date (or the normal operating cycle, whichever is longer), consisting of principal as well as any accrued interest) for the portion that is expected to be uncollectible.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23267
        /// </remarks>
        [JsonProperty("23267")]
        public AllowanceForNotesReceivableBalanceSheet AllowanceForNotesReceivable => new(_time, _securityIdentifier);

        /// <summary>
        /// This item is typically available for bank industry. It's a part of long-lived assets, which has been decided for sale in the future.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23268
        /// </remarks>
        [JsonProperty("23268")]
        public AssetsHeldForSaleBalanceSheet AssetsHeldForSale => new(_time, _securityIdentifier);

        /// <summary>
        /// A portion of a company's business that has been disposed of or sold.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23269
        /// </remarks>
        [JsonProperty("23269")]
        public AssetsOfDiscontinuedOperationsBalanceSheet AssetsOfDiscontinuedOperations => new(_time, _securityIdentifier);

        /// <summary>
        /// All indebtedness for borrowed money or the deferred purchase price of property or services, including without limitation reimbursement and other obligations with respect to surety bonds and letters of credit, all obligations evidenced by notes, bonds debentures or similar instruments, all capital lease obligations and all contingent obligations.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23271
        /// </remarks>
        [JsonProperty("23271")]
        public BankIndebtednessBalanceSheet BankIndebtedness => new(_time, _securityIdentifier);

        /// <summary>
        /// The carrying amount of a life insurance policy on an officer, executive or employee for which the reporting entity (a bank) is entitled to proceeds from the policy upon death of the insured or surrender of the insurance policy.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23273
        /// </remarks>
        [JsonProperty("23273")]
        public BankOwnedLifeInsuranceBalanceSheet BankOwnedLifeInsurance => new(_time, _securityIdentifier);

        /// <summary>
        /// The securities borrowed or on loan, which is the temporary loan of securities by a lender to a borrower in exchange for cash. This item is usually only available for bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23274
        /// </remarks>
        [JsonProperty("23274")]
        public SecurityBorrowedBalanceSheet SecurityBorrowed => new(_time, _securityIdentifier);

        /// <summary>
        /// Fixed assets that specifically deal with the facilities a company owns. Include the improvements associated with buildings.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23275
        /// </remarks>
        [JsonProperty("23275")]
        public BuildingsAndImprovementsBalanceSheet BuildingsAndImprovements => new(_time, _securityIdentifier);

        /// <summary>
        /// Short-term loan, typically 90 days, used by a company to finance seasonal working capital needs.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23278
        /// </remarks>
        [JsonProperty("23278")]
        public CommercialLoanBalanceSheet CommercialLoan => new(_time, _securityIdentifier);

        /// <summary>
        /// Commercial paper is a money-market security issued by large banks and corporations. It represents the current obligation for the company. There are four basic kinds of commercial paper: promissory notes, drafts, checks, and certificates of deposit. The maturities of these money market securities generally do not exceed 270 days.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23279
        /// </remarks>
        [JsonProperty("23279")]
        public CommercialPaperBalanceSheet CommercialPaper => new(_time, _securityIdentifier);

        /// <summary>
        /// The portion of the Stockholders' Equity that reflects the amount of common stock, which are units of ownership.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23280
        /// </remarks>
        [JsonProperty("23280")]
        public CommonStockEquityBalanceSheet CommonStockEquity => new(_time, _securityIdentifier);

        /// <summary>
        /// It represents carrying amount of long-lived asset under construction that includes construction costs to date on capital projects. Assets constructed, but not completed.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23282
        /// </remarks>
        [JsonProperty("23282")]
        public ConstructionInProgressBalanceSheet ConstructionInProgress => new(_time, _securityIdentifier);

        /// <summary>
        /// A loan that establishes consumer credit that is granted for personal use; usually unsecured and based on the borrower's integrity and ability to pay.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23283
        /// </remarks>
        [JsonProperty("23283")]
        public ConsumerLoanBalanceSheet ConsumerLoan => new(_time, _securityIdentifier);

        /// <summary>
        /// The company's minimum pension obligations to its former employees, paid into a defined pension plan to satisfy all pension entitlements that have been earned by employees to date.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23284
        /// </remarks>
        [JsonProperty("23284")]
        public MinimumPensionLiabilitiesBalanceSheet MinimumPensionLiabilities => new(_time, _securityIdentifier);

        /// <summary>
        /// Amounts receivable from customers on short-term negotiable time drafts drawn on and accepted by the institution (also known as banker's acceptance transactions) that are outstanding on the reporting date.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23285
        /// </remarks>
        [JsonProperty("23285")]
        public CustomerAcceptancesBalanceSheet CustomerAcceptances => new(_time, _securityIdentifier);

        /// <summary>
        /// The recognition of an asset where pension fund assets exceed promised benefits.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23288
        /// </remarks>
        [JsonProperty("23288")]
        public DefinedPensionBenefitBalanceSheet DefinedPensionBenefit => new(_time, _securityIdentifier);

        /// <summary>
        /// Fair values of all liabilities resulting from contracts that meet the criteria of being accounted for as derivative instruments; and which are expected to be extinguished or otherwise disposed of after one year or beyond the normal operating cycle.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23289
        /// </remarks>
        [JsonProperty("23289")]
        public DerivativeProductLiabilitiesBalanceSheet DerivativeProductLiabilities => new(_time, _securityIdentifier);

        /// <summary>
        /// Fair values of assets resulting from contracts that meet the criteria of being accounted for as derivative instruments, net of the effects of master netting arrangements.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23290
        /// </remarks>
        [JsonProperty("23290")]
        public DerivativeAssetsBalanceSheet DerivativeAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// Sum of the carrying values of dividends declared but unpaid on equity securities issued and outstanding (also includes dividends collected on behalf of another owner of securities that are being held by entity) by the entity.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23291
        /// </remarks>
        [JsonProperty("23291")]
        public DividendsPayableBalanceSheet DividendsPayable => new(_time, _securityIdentifier);

        /// <summary>
        /// Carrying amount as of the balance sheet date of the portion of the obligations recognized for the various benefits provided to former or inactive employees, their beneficiaries, and covered dependents after employment but before retirement.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23293
        /// </remarks>
        [JsonProperty("23293")]
        public EmployeeBenefitsBalanceSheet EmployeeBenefits => new(_time, _securityIdentifier);

        /// <summary>
        /// The amount borrowed by a bank, at the federal funds rate, from another bank to meet its reserve requirements. This item is typically available for the bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23295
        /// </remarks>
        [JsonProperty("23295")]
        public FederalFundsPurchasedBalanceSheet FederalFundsPurchased => new(_time, _securityIdentifier);

        /// <summary>
        /// Federal funds transactions involve lending (federal funds sold) or borrowing (federal funds purchased) of immediately available reserve balances. This item is typically available for the bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23296
        /// </remarks>
        [JsonProperty("23296")]
        public FederalFundsSoldBalanceSheet FederalFundsSold => new(_time, _securityIdentifier);

        /// <summary>
        /// Federal Home Loan Bank stock represents an equity interest in a FHLB. It does not have a readily determinable fair value because its ownership is restricted and it lacks a market (liquidity). This item is typically available for the bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23297
        /// </remarks>
        [JsonProperty("23297")]
        public FederalHomeLoanBankStockBalanceSheet FederalHomeLoanBankStock => new(_time, _securityIdentifier);

        /// <summary>
        /// Fair values as of the balance sheet date of all assets resulting from contracts that meet the criteria of being accounted for as derivative instruments, net of the effects of master netting arrangements.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23298
        /// </remarks>
        [JsonProperty("23298")]
        public FinancialAssetsBalanceSheet FinancialAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// The carrying value as of the balance sheet date of securities that an institution sells and agrees to repurchase (the identical or substantially the same securities) as a seller-borrower at a specified date for a specified price, also known as a repurchase agreement. This item is typically available for bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23299
        /// </remarks>
        [JsonProperty("23299")]
        public FinancialInstrumentsSoldUnderAgreementsToRepurchaseBalanceSheet FinancialInstrumentsSoldUnderAgreementsToRepurchase => new(_time, _securityIdentifier);

        /// <summary>
        /// The carrying amount as of the balance sheet date of merchandise or goods held by the company that are readily available for sale. This item is typically available for mining and manufacturing industries.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23300
        /// </remarks>
        [JsonProperty("23300")]
        public FinishedGoodsBalanceSheet FinishedGoods => new(_time, _securityIdentifier);

        /// <summary>
        /// It is one of the important fixed assets for transportation industry, which includes bicycles, cars, motorcycles, trains, ships, boats, and aircraft. This item is typically available for transportation industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23301
        /// </remarks>
        [JsonProperty("23301")]
        public FlightFleetVehicleAndRelatedEquipmentsBalanceSheet FlightFleetVehicleAndRelatedEquipments => new(_time, _securityIdentifier);

        /// <summary>
        /// The carrying amount as of the balance sheet date of all assets obtained in full or partial satisfaction of a debt arrangement through foreclosure proceedings or defeasance; includes real and personal property; equity interests in corporations, partnerships, and joint ventures; and beneficial interest in trusts. This item is typically typically available for bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23302
        /// </remarks>
        [JsonProperty("23302")]
        public ForeclosedAssetsBalanceSheet ForeclosedAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// Changes to accumulated comprehensive income that results from the process of translating subsidiary financial statements and foreign equity investments into functional currency of the reporting company.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23304
        /// </remarks>
        [JsonProperty("23304")]
        public ForeignCurrencyTranslationAdjustmentsBalanceSheet ForeignCurrencyTranslationAdjustments => new(_time, _securityIdentifier);

        /// <summary>
        /// This item represents certain charges made in the current period in inventory resulting from such factors as breakage, spoilage, employee theft and shoplifting. This item is typically available for manufacturing, mining and utility industries.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23307
        /// </remarks>
        [JsonProperty("23307")]
        public InventoriesAdjustmentsAllowancesBalanceSheet InventoriesAdjustmentsAllowances => new(_time, _securityIdentifier);

        /// <summary>
        /// This item represents the carrying amount on the company's balance sheet of its investments in common stock of an equity method. This item is typically available for the insurance industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23310
        /// </remarks>
        [JsonProperty("23310")]
        public InvestmentsInOtherVenturesUnderEquityMethodBalanceSheet InvestmentsInOtherVenturesUnderEquityMethod => new(_time, _securityIdentifier);

        /// <summary>
        /// Fixed Assets that specifically deal with land a company owns. Includes the improvements associated with land. This excludes land held for sale.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23312
        /// </remarks>
        [JsonProperty("23312")]
        public LandAndImprovementsBalanceSheet LandAndImprovements => new(_time, _securityIdentifier);

        /// <summary>
        /// Carrying amount at the balance sheet date of a long-lived, depreciable asset that is an addition or improvement to assets held under lease arrangement. This item is usually not available for the insurance industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23313
        /// </remarks>
        [JsonProperty("23313")]
        public LeasesBalanceSheet Leases => new(_time, _securityIdentifier);

        /// <summary>
        /// The obligations arising from the sale, disposal, or planned sale in the near future (generally within one year) of a disposal group, including a component of the entity (discontinued operation). This item is typically available for bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23314
        /// </remarks>
        [JsonProperty("23314")]
        public LiabilitiesOfDiscontinuedOperationsBalanceSheet LiabilitiesOfDiscontinuedOperations => new(_time, _securityIdentifier);

        /// <summary>
        /// The carrying value as of the balance sheet date of obligations drawn from a line of credit, which is a bank's commitment to make loans up to a specific amount.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23316
        /// </remarks>
        [JsonProperty("23316")]
        public LineOfCreditBalanceSheet LineOfCredit => new(_time, _securityIdentifier);

        /// <summary>
        /// It means the aggregate amount of loans receivable that will be sold to other entities. This item is typically available for bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23317
        /// </remarks>
        [JsonProperty("23317")]
        public LoansHeldForSaleBalanceSheet LoansHeldForSale => new(_time, _securityIdentifier);

        /// <summary>
        /// Reflects the carrying amount of unpaid loans issued to other institutions for cash needs or an asset purchase.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23318
        /// </remarks>
        [JsonProperty("23318")]
        public LoansReceivableBalanceSheet LoansReceivable => new(_time, _securityIdentifier);

        /// <summary>
        /// Fixed assets specifically dealing with tools, equipment and office furniture. This item is usually not available for the insurance and utility industries.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23319
        /// </remarks>
        [JsonProperty("23319")]
        public MachineryFurnitureEquipmentBalanceSheet MachineryFurnitureEquipment => new(_time, _securityIdentifier);

        /// <summary>
        /// Aggregated amount of unprocessed materials to be used in manufacturing or production process and supplies that will be consumed. This item is typically available for the utility industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23320
        /// </remarks>
        [JsonProperty("23320")]
        public MaterialsAndSuppliesBalanceSheet MaterialsAndSupplies => new(_time, _securityIdentifier);

        /// <summary>
        /// A fixed asset that represents strictly mineral type properties. This item is typically available for mining industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23321
        /// </remarks>
        [JsonProperty("23321")]
        public MineralPropertiesBalanceSheet MineralProperties => new(_time, _securityIdentifier);

        /// <summary>
        /// This is a lien on real estate to protect a lender. This item is typically available for bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23322
        /// </remarks>
        [JsonProperty("23322")]
        public MortgageLoanBalanceSheet MortgageLoan => new(_time, _securityIdentifier);

        /// <summary>
        /// It means the aggregate amount of mortgage and consumer loans. This item is typically available for the insurance industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23323
        /// </remarks>
        [JsonProperty("23323")]
        public MortgageAndConsumerloansBalanceSheet MortgageAndConsumerloans => new(_time, _securityIdentifier);

        /// <summary>
        /// An amount representing an agreement for an unconditional promise by the maker to pay the entity (holder) a definite sum of money at a future date(s) within one year of the balance sheet date or the normal operating cycle. Such amount may include accrued interest receivable in accordance with the terms of the note. The note also may contain provisions including a discount or premium, payable on demand, secured, or unsecured, interest bearing or non-interest bearing, among myriad other features and characteristics. This item is typically available for bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23328
        /// </remarks>
        [JsonProperty("23328")]
        public GrossNotesReceivableBalanceSheet GrossNotesReceivable => new(_time, _securityIdentifier);

        /// <summary>
        /// Other non-current assets that are not otherwise classified.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23329
        /// </remarks>
        [JsonProperty("23329")]
        public OtherAssetsBalanceSheet OtherAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// Other Capital Stock that is not otherwise classified.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23330
        /// </remarks>
        [JsonProperty("23330")]
        public OtherCapitalStockBalanceSheet OtherCapitalStock => new(_time, _securityIdentifier);

        /// <summary>
        /// Other current assets that are not otherwise classified.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23331
        /// </remarks>
        [JsonProperty("23331")]
        public OtherCurrentAssetsBalanceSheet OtherCurrentAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// Short Term Borrowings that are not otherwise classified.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23332
        /// </remarks>
        [JsonProperty("23332")]
        public OtherCurrentBorrowingsBalanceSheet OtherCurrentBorrowings => new(_time, _securityIdentifier);

        /// <summary>
        /// Other adjustments to stockholders' equity that is not otherwise classified, including other reserves.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23335
        /// </remarks>
        [JsonProperty("23335")]
        public OtherEquityAdjustmentsBalanceSheet OtherEquityAdjustments => new(_time, _securityIdentifier);

        /// <summary>
        /// Other non-current inventories not otherwise classified.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23337
        /// </remarks>
        [JsonProperty("23337")]
        public OtherInventoriesBalanceSheet OtherInventories => new(_time, _securityIdentifier);

        /// <summary>
        /// An item represents all the other investments or/and securities that cannot be defined into any category above. This item is typically available for the insurance industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23338
        /// </remarks>
        [JsonProperty("23338")]
        public OtherInvestedAssetsBalanceSheet OtherInvestedAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// Other non-current assets that are not otherwise classified.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23339
        /// </remarks>
        [JsonProperty("23339")]
        public OtherNonCurrentAssetsBalanceSheet OtherNonCurrentAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// Other fixed assets not otherwise classified.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23340
        /// </remarks>
        [JsonProperty("23340")]
        public OtherPropertiesBalanceSheet OtherProperties => new(_time, _securityIdentifier);

        /// <summary>
        /// The Carrying amount as of the balance sheet date of other real estate, which may include real estate investments, real estate loans that qualify as investments in real estate, and premises that are no longer used in operations may also be included in real estate owned. This does not include real estate assets taken in settlement of troubled loans through surrender or foreclosure. This item is typically available for bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23341
        /// </remarks>
        [JsonProperty("23341")]
        public OtherRealEstateOwnedBalanceSheet OtherRealEstateOwned => new(_time, _securityIdentifier);

        /// <summary>
        /// Other non-current receivables not otherwise classified.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23342
        /// </remarks>
        [JsonProperty("23342")]
        public OtherReceivablesBalanceSheet OtherReceivables => new(_time, _securityIdentifier);

        /// <summary>
        /// A loan issued by an insurance company that uses the cash value of a person's life insurance policy as collateral. This item is usually only available in the insurance industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23344
        /// </remarks>
        [JsonProperty("23344")]
        public NonCurrentPensionAndOtherPostretirementBenefitPlansBalanceSheet NonCurrentPensionAndOtherPostretirementBenefitPlans => new(_time, _securityIdentifier);

        /// <summary>
        /// A loan issued by an insurance company that uses the cash value of a person's life insurance policy as collateral. This item is usually only available for insurance industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23345
        /// </remarks>
        [JsonProperty("23345")]
        public PolicyLoansBalanceSheet PolicyLoans => new(_time, _securityIdentifier);

        /// <summary>
        /// A class of ownership in a company that has a higher claim on the assets and earnings than common stock. Preferred stock generally has a dividend that must be paid out before dividends to common stockholders and the shares usually do not have voting rights.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23347
        /// </remarks>
        [JsonProperty("23347")]
        public PreferredStockEquityBalanceSheet PreferredStockEquity => new(_time, _securityIdentifier);

        /// <summary>
        /// Tangible assets that are held by an entity for use in the production or supply of goods and services, for rental to others, or for administrative purposes and that are expected to provide economic benefit for more than one year. This item is available for manufacturing, bank and transportation industries.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23351
        /// </remarks>
        [JsonProperty("23351")]
        public PropertiesBalanceSheet Properties => new(_time, _securityIdentifier);

        /// <summary>
        /// Provisions are created to protect the interests of one or both parties named in a contract or legal document which is a preparatory action or measure. Current provision is expired within one accounting period.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23352
        /// </remarks>
        [JsonProperty("23352")]
        public CurrentProvisionsBalanceSheet CurrentProvisions => new(_time, _securityIdentifier);

        /// <summary>
        /// Provisions are created to protect the interests of one or both parties named in a contract or legal document which is a preparatory action or measure. Long-term provision is expired beyond one accounting period.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23353
        /// </remarks>
        [JsonProperty("23353")]
        public LongTermProvisionsBalanceSheet LongTermProvisions => new(_time, _securityIdentifier);

        /// <summary>
        /// Carrying amount as of the balance sheet data of unprocessed items to be consumed in the manufacturing or production process. This item is available for manufacturing and mining industries.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23355
        /// </remarks>
        [JsonProperty("23355")]
        public RawMaterialsBalanceSheet RawMaterials => new(_time, _securityIdentifier);

        /// <summary>
        /// A provision relating to a written agreement to receive money at a specified future date(s) (within one year from the reporting date or the normal operating cycle, whichever is longer), consisting of principal as well as any accrued interest).
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23358
        /// </remarks>
        [JsonProperty("23358")]
        public ReceivablesAdjustmentsAllowancesBalanceSheet ReceivablesAdjustmentsAllowances => new(_time, _securityIdentifier);

        /// <summary>
        /// Carrying amount as of the balance sheet date of capitalized costs of regulated entities that are expected to be recovered through revenue sources over one year or beyond the normal operating cycle.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23359
        /// </remarks>
        [JsonProperty("23359")]
        public RegulatoryAssetsBalanceSheet RegulatoryAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// The amount for the individual regulatory noncurrent liability as itemized in a table of regulatory noncurrent liabilities as of the end of the period. Such things as the costs of energy efficiency programs and low-income energy assistances programs and deferred fuel. This item is usually only available for utility industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23360
        /// </remarks>
        [JsonProperty("23360")]
        public RegulatoryLiabilitiesBalanceSheet RegulatoryLiabilities => new(_time, _securityIdentifier);

        /// <summary>
        /// The carrying amount as of the balance sheet date of the known and estimated amounts owed to insurers under reinsurance treaties or other arrangements. This item is usually only available for insurance industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23361
        /// </remarks>
        [JsonProperty("23361")]
        public ReinsuranceBalancesPayableBalanceSheet ReinsuranceBalancesPayable => new(_time, _securityIdentifier);

        /// <summary>
        /// The carrying amounts of cash and cash equivalent items, which are restricted as to withdrawal or usage. Restrictions may include legally restricted deposits held as compensating balances against short-term borrowing arrangements, contracts entered into with others, or entity statements of intention with regard to particular deposits; however, time deposits and short-term certificates of deposit are not generally included in legally restricted deposits. Excludes compensating balance arrangements that are not agreements, which legally restrict the use of cash amounts shown on the balance sheet. For a classified balance sheet, represents the current portion only (the non-current portion has a separate concept); for an unclassified balance sheet represents the entire amount. This item is usually not available for bank and insurance industries.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23365
        /// </remarks>
        [JsonProperty("23365")]
        public RestrictedCashBalanceSheet RestrictedCash => new(_time, _securityIdentifier);

        /// <summary>
        /// The carrying amounts of cash and cash equivalent items which are restricted as to withdrawal or usage. This item is available for bank and insurance industries.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23366
        /// </remarks>
        [JsonProperty("23366")]
        public RestrictedCashAndCashEquivalentsBalanceSheet RestrictedCashAndCashEquivalents => new(_time, _securityIdentifier);

        /// <summary>
        /// The cash and investments whose use in whole or in part is restricted for the long-term, generally by contractual agreements or regulatory requirements. This item is usually only available for bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23367
        /// </remarks>
        [JsonProperty("23367")]
        public RestrictedCashAndInvestmentsBalanceSheet RestrictedCashAndInvestments => new(_time, _securityIdentifier);

        /// <summary>
        /// Shares of stock for which sale is contractually or governmentally restricted for a given period of time. Stock that is acquired through an employee stock option plan or other private means may not be transferred. Restricted stock must be traded in compliance with special SEC regulations.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23368
        /// </remarks>
        [JsonProperty("23368")]
        public RestrictedCommonStockBalanceSheet RestrictedCommonStock => new(_time, _securityIdentifier);

        /// <summary>
        /// Investments whose use is restricted in whole or in part, generally by contractual agreements or regulatory requirements. This item is usually only available for bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23369
        /// </remarks>
        [JsonProperty("23369")]
        public RestrictedInvestmentsBalanceSheet RestrictedInvestments => new(_time, _securityIdentifier);

        /// <summary>
        /// Carrying amount due within one year of the balance sheet date (or one operating cycle, if longer) from tax authorities as of the balance sheet date representing refunds of overpayments or recoveries based on agreed-upon resolutions of disputes. This item is usually not available for bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23372
        /// </remarks>
        [JsonProperty("23372")]
        public TaxesReceivableBalanceSheet TaxesReceivable => new(_time, _securityIdentifier);

        /// <summary>
        /// Stockholder's Equity plus Long Term Debt.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23374
        /// </remarks>
        [JsonProperty("23374")]
        public TotalCapitalizationBalanceSheet TotalCapitalization => new(_time, _securityIdentifier);

        /// <summary>
        /// Revenue received by a firm but not yet reported as income. This item is usually only available for utility industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23375
        /// </remarks>
        [JsonProperty("23375")]
        public TotalDeferredCreditsAndOtherNonCurrentLiabilitiesBalanceSheet TotalDeferredCreditsAndOtherNonCurrentLiabilities => new(_time, _securityIdentifier);

        /// <summary>
        /// Revenues that are not currently billed from the customer under the terms of the contract. This item is usually only available for utility industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23376
        /// </remarks>
        [JsonProperty("23376")]
        public UnbilledReceivablesBalanceSheet UnbilledReceivables => new(_time, _securityIdentifier);

        /// <summary>
        /// A profit or loss that results from holding onto an asset rather than cashing it in and officially taking the profit or loss.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23377
        /// </remarks>
        [JsonProperty("23377")]
        public UnrealizedGainLossBalanceSheet UnrealizedGainLoss => new(_time, _securityIdentifier);

        /// <summary>
        /// Work, or goods, in the process of being fabricated or manufactured but not yet completed as finished goods. This item is usually available for manufacturing and mining industries.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23378
        /// </remarks>
        [JsonProperty("23378")]
        public WorkInProcessBalanceSheet WorkInProcess => new(_time, _securityIdentifier);

        /// <summary>
        /// This item is usually not available for bank and insurance industries.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23379
        /// </remarks>
        [JsonProperty("23379")]
        public OtherNonCurrentLiabilitiesBalanceSheet OtherNonCurrentLiabilities => new(_time, _securityIdentifier);

        /// <summary>
        /// Current Portion of Capital Lease Obligation plus Long Term Portion of Capital Lease Obligation.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23380
        /// </remarks>
        [JsonProperty("23380")]
        public CapitalLeaseObligationsBalanceSheet CapitalLeaseObligations => new(_time, _securityIdentifier);

        /// <summary>
        /// This item is available for bank and insurance industries.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23381
        /// </remarks>
        [JsonProperty("23381")]
        public OtherLiabilitiesBalanceSheet OtherLiabilities => new(_time, _securityIdentifier);

        /// <summary>
        /// Payables and Accrued Expenses that are not defined as Trade, Tax or Dividends related.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23382
        /// </remarks>
        [JsonProperty("23382")]
        public OtherPayableBalanceSheet OtherPayable => new(_time, _securityIdentifier);

        /// <summary>
        /// The company's total book value less the value of any intangible assets. Methodology: Common Stock Equity minus Goodwill and Other Intangible Assets
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23383
        /// </remarks>
        [JsonProperty("23383")]
        public TangibleBookValueBalanceSheet TangibleBookValue => new(_time, _securityIdentifier);

        /// <summary>
        /// Total Equity equals Preferred Stock Equity + Common Stock Equity.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23384
        /// </remarks>
        [JsonProperty("23384")]
        public TotalEquityBalanceSheet TotalEquity => new(_time, _securityIdentifier);

        /// <summary>
        /// Current Assets minus Current Liabilities. This item is usually not available for bank and insurance industries.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23385
        /// </remarks>
        [JsonProperty("23385")]
        public WorkingCapitalBalanceSheet WorkingCapital => new(_time, _securityIdentifier);

        /// <summary>
        /// All borrowings incurred by the company including debt and capital lease obligations.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23386
        /// </remarks>
        [JsonProperty("23386")]
        public TotalDebtBalanceSheet TotalDebt => new(_time, _securityIdentifier);

        /// <summary>
        /// The amount for the other plant related to the utility industry fix assets.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23388
        /// </remarks>
        [JsonProperty("23388")]
        public CommonUtilityPlantBalanceSheet CommonUtilityPlant => new(_time, _securityIdentifier);

        /// <summary>
        /// The amount for the electric plant related to the utility industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23389
        /// </remarks>
        [JsonProperty("23389")]
        public ElectricUtilityPlantBalanceSheet ElectricUtilityPlant => new(_time, _securityIdentifier);

        /// <summary>
        /// The amount for the natural gas, fuel and other items related to the utility industry, which might include oil and gas wells, the properties to exploit oil and gas or liquefied natural gas sites.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23390
        /// </remarks>
        [JsonProperty("23390")]
        public NaturalGasFuelAndOtherBalanceSheet NaturalGasFuelAndOther => new(_time, _securityIdentifier);

        /// <summary>
        /// Net utility plant might include water production, electric utility plan, natural gas, fuel and other, common utility plant and accumulated depreciation. This item is usually only available for utility industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23391
        /// </remarks>
        [JsonProperty("23391")]
        public NetUtilityPlantBalanceSheet NetUtilityPlant => new(_time, _securityIdentifier);

        /// <summary>
        /// The amount for a facility and plant that provides water which might include wells, reservoirs, pumping stations, and control facilities; and waste water systems which includes the waste treatment and disposal facility and equipment. This item is usually only available for utility industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23392
        /// </remarks>
        [JsonProperty("23392")]
        public WaterProductionBalanceSheet WaterProduction => new(_time, _securityIdentifier);

        /// <summary>
        /// Number of Common or Ordinary Shares.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23393
        /// </remarks>
        [JsonProperty("23393")]
        public OrdinarySharesNumberBalanceSheet OrdinarySharesNumber => new(_time, _securityIdentifier);

        /// <summary>
        /// Number of Preferred Shares.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23394
        /// </remarks>
        [JsonProperty("23394")]
        public PreferredSharesNumberBalanceSheet PreferredSharesNumber => new(_time, _securityIdentifier);

        /// <summary>
        /// Number of Treasury Shares.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23395
        /// </remarks>
        [JsonProperty("23395")]
        public TreasurySharesNumberBalanceSheet TreasurySharesNumber => new(_time, _securityIdentifier);

        /// <summary>
        /// This will serve as the "parent" value to AccountsReceivable (DataId 23001) and OtherReceivables (DataId 23342) for all company financials reported in the IFRS GAAP.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23399
        /// </remarks>
        [JsonProperty("23399")]
        public TradingAndOtherReceivableBalanceSheet TradingAndOtherReceivable => new(_time, _securityIdentifier);

        /// <summary>
        /// <remarks> Morningstar DataId: 23400 </remarks>
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23400
        /// </remarks>
        [JsonProperty("23400")]
        public EquityAttributableToOwnersOfParentBalanceSheet EquityAttributableToOwnersOfParent => new(_time, _securityIdentifier);

        /// <summary>
        /// The carrying value as of the balance sheet date of securities loaned to other broker dealers, typically used by such parties to cover short sales, secured by cash or other securities furnished by such parties until the borrowing is closed.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23401
        /// </remarks>
        [JsonProperty("23401")]
        public SecuritiesLoanedBalanceSheet SecuritiesLoaned => new(_time, _securityIdentifier);

        /// <summary>
        /// Net assets in physical form. This is calculated using Stockholders' Equity less Intangible Assets (including Goodwill).
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23403
        /// </remarks>
        [JsonProperty("23403")]
        public NetTangibleAssetsBalanceSheet NetTangibleAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// Amounts owed to the company from a non-arm's length entity, due within the company's current operating cycle.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23404
        /// </remarks>
        [JsonProperty("23404")]
        public DuefromRelatedPartiesCurrentBalanceSheet DuefromRelatedPartiesCurrent => new(_time, _securityIdentifier);

        /// <summary>
        /// Amounts owed to the company from a non-arm's length entity, due after the company's current operating cycle.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23405
        /// </remarks>
        [JsonProperty("23405")]
        public DuefromRelatedPartiesNonCurrentBalanceSheet DuefromRelatedPartiesNonCurrent => new(_time, _securityIdentifier);

        /// <summary>
        /// Amounts owed by the company to a non-arm's length entity.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23406
        /// </remarks>
        [JsonProperty("23406")]
        public DuetoRelatedPartiesBalanceSheet DuetoRelatedParties => new(_time, _securityIdentifier);

        /// <summary>
        /// Amounts owed by the company to a non-arm's length entity that has to be repaid within the company's current operating cycle.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23407
        /// </remarks>
        [JsonProperty("23407")]
        public DuetoRelatedPartiesCurrentBalanceSheet DuetoRelatedPartiesCurrent => new(_time, _securityIdentifier);

        /// <summary>
        /// Amounts owed by the company to a non-arm's length entity that has to be repaid after the company's current operating cycle.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23408
        /// </remarks>
        [JsonProperty("23408")]
        public DuetoRelatedPartiesNonCurrentBalanceSheet DuetoRelatedPartiesNonCurrent => new(_time, _securityIdentifier);

        /// <summary>
        /// Company's investments in properties net of accumulated depreciation, which generate a return.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23410
        /// </remarks>
        [JsonProperty("23410")]
        public InvestmentPropertiesBalanceSheet InvestmentProperties => new(_time, _securityIdentifier);

        /// <summary>
        /// A stake in any company which is more than 51%.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23411
        /// </remarks>
        [JsonProperty("23411")]
        public InvestmentsinSubsidiariesatCostBalanceSheet InvestmentsinSubsidiariesatCost => new(_time, _securityIdentifier);

        /// <summary>
        /// A stake in any company which is more than 20% but less than 50%.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23412
        /// </remarks>
        [JsonProperty("23412")]
        public InvestmentsinAssociatesatCostBalanceSheet InvestmentsinAssociatesatCost => new(_time, _securityIdentifier);

        /// <summary>
        /// A 50% stake in any company in which remaining 50% belongs to other company.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23413
        /// </remarks>
        [JsonProperty("23413")]
        public InvestmentsinJointVenturesatCostBalanceSheet InvestmentsinJointVenturesatCost => new(_time, _securityIdentifier);

        /// <summary>
        /// Represents the sum of all financial investments (trading securities, available-for-sale securities, held-to-maturity securities, etc.)
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23414
        /// </remarks>
        [JsonProperty("23414")]
        public InvestmentinFinancialAssetsBalanceSheet InvestmentinFinancialAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// Accounts owed to the bank in relation to capital leases. Capital/ finance lease obligation are contractual obligations that arise from obtaining the use of property or equipment via a capital lease contract.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23415
        /// </remarks>
        [JsonProperty("23415")]
        public FinanceLeaseReceivablesBalanceSheet FinanceLeaseReceivables => new(_time, _securityIdentifier);

        /// <summary>
        /// This represents loans that entitle the lender (or the holder of loan debenture) to convert the loan to common or preferred stock (ordinary or preference shares) within the next 12 months or operating cycle.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23418
        /// </remarks>
        [JsonProperty("23418")]
        public ConvertibleLoansCurrentBalanceSheet ConvertibleLoansCurrent => new(_time, _securityIdentifier);

        /// <summary>
        /// A debt financing obligation issued by a bank or similar financial institution to a company, that entitles the lender or holder of the instrument to interest payments and the repayment of principal at a specified time within the next 12 months or operating cycle.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23419
        /// </remarks>
        [JsonProperty("23419")]
        public BankLoansCurrentBalanceSheet BankLoansCurrent => new(_time, _securityIdentifier);

        /// <summary>
        /// Other loans between the customer and bank which cannot be identified by other specific items in the Debt section, due within the next 12 months or operating cycle.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23420
        /// </remarks>
        [JsonProperty("23420")]
        public OtherLoansCurrentBalanceSheet OtherLoansCurrent => new(_time, _securityIdentifier);

        /// <summary>
        /// Sum of accrued liabilities and deferred income (amount received in advance but the services are not provided in respect of amount).
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23422
        /// </remarks>
        [JsonProperty("23422")]
        public AccruedandDeferredIncomeBalanceSheet AccruedandDeferredIncome => new(_time, _securityIdentifier);

        /// <summary>
        /// A debt financing obligation issued by a bank or similar financial institution to a company, that entitles the lender or holder of the instrument to interest payments and the repayment of principal at a specified time beyond the current accounting period.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23426
        /// </remarks>
        [JsonProperty("23426")]
        public BankLoansNonCurrentBalanceSheet BankLoansNonCurrent => new(_time, _securityIdentifier);

        /// <summary>
        /// Other loans between the customer and bank which cannot be identified by other specific items in the Debt section, due beyond the current operating cycle.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23427
        /// </remarks>
        [JsonProperty("23427")]
        public OtherLoansNonCurrentBalanceSheet OtherLoansNonCurrent => new(_time, _securityIdentifier);

        /// <summary>
        /// Other reserves owned by the company that cannot be identified by other specific items in the Reserves section.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23430
        /// </remarks>
        [JsonProperty("23430")]
        public OtherReservesBalanceSheet OtherReserves => new(_time, _securityIdentifier);

        /// <summary>
        /// The aggregate amount of loans and advances made to a bank or financial institution.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23432
        /// </remarks>
        [JsonProperty("23432")]
        public LoansandAdvancestoBankBalanceSheet LoansandAdvancestoBank => new(_time, _securityIdentifier);

        /// <summary>
        /// The aggregate amount of loans and advances made to customers.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23433
        /// </remarks>
        [JsonProperty("23433")]
        public LoansandAdvancestoCustomerBalanceSheet LoansandAdvancestoCustomer => new(_time, _securityIdentifier);

        /// <summary>
        /// Investments backed by the central government, it usually carries less risk than other investments.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23434
        /// </remarks>
        [JsonProperty("23434")]
        public TreasuryBillsandOtherEligibleBillsBalanceSheet TreasuryBillsandOtherEligibleBills => new(_time, _securityIdentifier);

        /// <summary>
        /// Investments in shares of a company representing ownership in that company.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23435
        /// </remarks>
        [JsonProperty("23435")]
        public EquitySharesInvestmentsBalanceSheet EquitySharesInvestments => new(_time, _securityIdentifier);

        /// <summary>
        /// Banks investment in the ongoing entity.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23436
        /// </remarks>
        [JsonProperty("23436")]
        public DepositsbyBankBalanceSheet DepositsbyBank => new(_time, _securityIdentifier);

        /// <summary>
        /// Carrying value of amounts transferred by customers to third parties for security purposes that are expected to be returned or applied towards payment after one year or beyond the operating cycle, if longer.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23437
        /// </remarks>
        [JsonProperty("23437")]
        public CustomerAccountsBalanceSheet CustomerAccounts => new(_time, _securityIdentifier);

        /// <summary>
        /// Carrying amount as of the balance sheet date of drafts and bills of exchange that have been accepted by the reporting bank or by others for its own account, as its liability to holders of the drafts.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23438
        /// </remarks>
        [JsonProperty("23438")]
        public ItemsinTheCourseofTransmissiontoOtherBanksBalanceSheet ItemsinTheCourseofTransmissiontoOtherBanks => new(_time, _securityIdentifier);

        /// <summary>
        /// Total carrying amount of total trading, financial liabilities and debt in a non-differentiated balance sheet.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23439
        /// </remarks>
        [JsonProperty("23439")]
        public TradingandFinancialLiabilitiesBalanceSheet TradingandFinancialLiabilities => new(_time, _securityIdentifier);

        /// <summary>
        /// Any debt financial instrument issued instead of cash loan.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23440
        /// </remarks>
        [JsonProperty("23440")]
        public DebtSecuritiesinIssueBalanceSheet DebtSecuritiesinIssue => new(_time, _securityIdentifier);

        /// <summary>
        /// The total carrying value of securities loaned to other broker dealers, typically used by such parties to cover short sales, secured by cash or other securities furnished by such parties until the borrowing is closed; in a Non-Differentiated Balance Sheet.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23441
        /// </remarks>
        [JsonProperty("23441")]
        public SubordinatedLiabilitiesBalanceSheet SubordinatedLiabilities => new(_time, _securityIdentifier);

        /// <summary>
        /// Provisions are created to protect the interests of one or both parties named in a contract or legal document, which is a preparatory action or measure. Current provision is expired within one accounting period.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23443
        /// </remarks>
        [JsonProperty("23443")]
        public ProvisionsTotalBalanceSheet ProvisionsTotal => new(_time, _securityIdentifier);

        /// <summary>
        /// A contract that allows for the use of an asset, but does not convey rights of ownership of the asset. An operating lease is not capitalized; it is accounted for as a rental expense in what is known as "off balance sheet financing." For the lessor, the asset being leased is accounted for as an asset and is depreciated as such.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23444
        /// </remarks>
        [JsonProperty("23444")]
        public OperatingLeaseAssetsBalanceSheet OperatingLeaseAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// Amounts owing to policy holders who have filed claims but have not yet been settled or paid.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23445
        /// </remarks>
        [JsonProperty("23445")]
        public ClaimsOutstandingBalanceSheet ClaimsOutstanding => new(_time, _securityIdentifier);

        /// <summary>
        /// Liabilities due within the next 12 months related from an asset classified as Held for Sale.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23452
        /// </remarks>
        [JsonProperty("23452")]
        public LiabilitiesHeldforSaleCurrentBalanceSheet LiabilitiesHeldforSaleCurrent => new(_time, _securityIdentifier);

        /// <summary>
        /// Liabilities related to an asset classified as held for sale excluding the portion due the next 12 months or operating cycle.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23453
        /// </remarks>
        [JsonProperty("23453")]
        public LiabilitiesHeldforSaleNonCurrentBalanceSheet LiabilitiesHeldforSaleNonCurrent => new(_time, _securityIdentifier);

        /// <summary>
        /// Debt securities held as investments.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23455
        /// </remarks>
        [JsonProperty("23455")]
        public DebtSecuritiesBalanceSheet DebtSecurities => new(_time, _securityIdentifier);

        /// <summary>
        /// Represents the total amount of long-term capital leases that must be paid within the next accounting period for a Non- Differentiated Balance Sheet. Capital lease obligations are contractual obligations that arise from obtaining the use of property or equipment via a capital lease contract.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23456
        /// </remarks>
        [JsonProperty("23456")]
        public TotalFinancialLeaseObligationsBalanceSheet TotalFinancialLeaseObligations => new(_time, _securityIdentifier);

        /// <summary>
        /// Sum of Accrued Liabilities and Deferred Income (amount received in advance but the services are not provided in respect of amount) due within 1 year.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23457
        /// </remarks>
        [JsonProperty("23457")]
        public AccruedandDeferredIncomeCurrentBalanceSheet AccruedandDeferredIncomeCurrent => new(_time, _securityIdentifier);

        /// <summary>
        /// Sum of Accrued Liabilities and Deferred Income (amount received in advance but the services are not provided in respect of amount) due after 1 year.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23458
        /// </remarks>
        [JsonProperty("23458")]
        public AccruedandDeferredIncomeNonCurrentBalanceSheet AccruedandDeferredIncomeNonCurrent => new(_time, _securityIdentifier);

        /// <summary>
        /// Accounts owed to the bank in relation to capital leases to be received within the next accounting period. Capital/ finance lease obligations are contractual obligations that arise from obtaining the use of property or equipment via a capital lease contract.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23459
        /// </remarks>
        [JsonProperty("23459")]
        public FinanceLeaseReceivablesCurrentBalanceSheet FinanceLeaseReceivablesCurrent => new(_time, _securityIdentifier);

        /// <summary>
        /// Accounts owed to the bank in relation to capital leases to be received beyond the next accounting period. Capital/ finance lease obligations are contractual obligations that arise from obtaining the use of property or equipment via a capital lease contract.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23460
        /// </remarks>
        [JsonProperty("23460")]
        public FinanceLeaseReceivablesNonCurrentBalanceSheet FinanceLeaseReceivablesNonCurrent => new(_time, _securityIdentifier);

        /// <summary>
        /// Financial related liabilities due within one year, including short term and current portions of long-term debt, capital leases and derivative liabilities.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23462
        /// </remarks>
        [JsonProperty("23462")]
        public FinancialLiabilitiesCurrentBalanceSheet FinancialLiabilitiesCurrent => new(_time, _securityIdentifier);

        /// <summary>
        /// Financial related liabilities due beyond one year, including long term debt, capital leases and derivative liabilities.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23463
        /// </remarks>
        [JsonProperty("23463")]
        public FinancialLiabilitiesNonCurrentBalanceSheet FinancialLiabilitiesNonCurrent => new(_time, _securityIdentifier);

        /// <summary>
        /// Financial assets that are held at fair value through profit or loss comprise assets held for trading and those financial assets designated as being held at fair value through profit or loss.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23466
        /// </remarks>
        [JsonProperty("23466")]
        public FinancialAssetsDesignatedasFairValueThroughProfitorLossTotalBalanceSheet FinancialAssetsDesignatedasFairValueThroughProfitorLossTotal => new(_time, _securityIdentifier);

        /// <summary>
        /// Carrying amount due within one year of the balance sheet date (or one operating cycle, if longer) from tax authorities as of the balance sheet date representing refunds of overpayments or recoveries based on agreed-upon resolutions of disputes, and current deferred tax assets.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23468
        /// </remarks>
        [JsonProperty("23468")]
        public TaxesAssetsCurrentBalanceSheet TaxesAssetsCurrent => new(_time, _securityIdentifier);

        /// <summary>
        /// Other equity instruments issued by the company that cannot be identified by other specific items in the Equity section.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23469
        /// </remarks>
        [JsonProperty("23469")]
        public OtherEquityInterestBalanceSheet OtherEquityInterest => new(_time, _securityIdentifier);

        /// <summary>
        /// Carrying amount of any interest-bearing loan which is due after one year.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23470
        /// </remarks>
        [JsonProperty("23470")]
        public InterestBearingBorrowingsNonCurrentBalanceSheet InterestBearingBorrowingsNonCurrent => new(_time, _securityIdentifier);

        /// <summary>
        /// Non-interest bearing borrowings due after a year.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23471
        /// </remarks>
        [JsonProperty("23471")]
        public NonInterestBearingBorrowingsNonCurrentBalanceSheet NonInterestBearingBorrowingsNonCurrent => new(_time, _securityIdentifier);

        /// <summary>
        /// Sum of all non-current payables and accrued expenses.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23472
        /// </remarks>
        [JsonProperty("23472")]
        public TradeandOtherPayablesNonCurrentBalanceSheet TradeandOtherPayablesNonCurrent => new(_time, _securityIdentifier);

        /// <summary>
        /// Non-interest bearing deposits in other financial institutions for short periods of time, usually less than 12 months.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23474
        /// </remarks>
        [JsonProperty("23474")]
        public NonInterestBearingBorrowingsCurrentBalanceSheet NonInterestBearingBorrowingsCurrent => new(_time, _securityIdentifier);

        /// <summary>
        /// Total of the carrying values as of the balance sheet date of obligations incurred through that date and payable for obligations related to services received from employees, such as accrued salaries and bonuses, payroll taxes and fringe benefits.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23475
        /// </remarks>
        [JsonProperty("23475")]
        public PensionandOtherPostRetirementBenefitPlansCurrentBalanceSheet PensionandOtherPostRetirementBenefitPlansCurrent => new(_time, _securityIdentifier);

        /// <summary>
        /// Reflects the carrying amount of any other unpaid loans, an asset of the bank.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23478
        /// </remarks>
        [JsonProperty("23478")]
        public OtherLoanAssetsBalanceSheet OtherLoanAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// Total value collateral assets pledged to the bank that can be sold or used as collateral for other loans.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23480
        /// </remarks>
        [JsonProperty("23480")]
        public AssetsPledgedasCollateralSubjecttoSaleorRepledgingTotalBalanceSheet AssetsPledgedasCollateralSubjecttoSaleorRepledgingTotal => new(_time, _securityIdentifier);

        /// <summary>
        /// Sum of total tax assets in a Non-Differentiated Balance Sheet, includes Tax Receivables and Deferred Tax Assets.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23481
        /// </remarks>
        [JsonProperty("23481")]
        public TaxAssetsTotalBalanceSheet TaxAssetsTotal => new(_time, _securityIdentifier);

        /// <summary>
        /// Borrowings from the central bank, which are primarily used to cover shortages in the required reserve balance and liquidity shortages.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23482
        /// </remarks>
        [JsonProperty("23482")]
        public AdvancesfromCentralBanksBalanceSheet AdvancesfromCentralBanks => new(_time, _securityIdentifier);

        /// <summary>
        /// A savings certificate entitling the bearer to receive interest. A CD bears a maturity date, a specified fixed interest rate and can be issued in any denomination.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23484
        /// </remarks>
        [JsonProperty("23484")]
        public DepositCertificatesBalanceSheet DepositCertificates => new(_time, _securityIdentifier);

        /// <summary>
        /// Non-interest bearing deposits in other financial institutions for relatively short periods of time; on a Non-Differentiated Balance Sheet.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23487
        /// </remarks>
        [JsonProperty("23487")]
        public NonInterestBearingBorrowingsTotalBalanceSheet NonInterestBearingBorrowingsTotal => new(_time, _securityIdentifier);

        /// <summary>
        /// Other borrowings by the bank to fund its activities that cannot be identified by other specific items in the Liabilities section.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23488
        /// </remarks>
        [JsonProperty("23488")]
        public OtherBorrowedFundsBalanceSheet OtherBorrowedFunds => new(_time, _securityIdentifier);

        /// <summary>
        /// Financial liabilities that are held at fair value through profit or loss.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23490
        /// </remarks>
        [JsonProperty("23490")]
        public FinancialLiabilitiesDesignatedasFairValueThroughProfitorLossTotalBalanceSheet FinancialLiabilitiesDesignatedasFairValueThroughProfitorLossTotal => new(_time, _securityIdentifier);

        /// <summary>
        /// Financial liabilities carried at amortized cost.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23491
        /// </remarks>
        [JsonProperty("23491")]
        public FinancialLiabilitiesMeasuredatAmortizedCostTotalBalanceSheet FinancialLiabilitiesMeasuredatAmortizedCostTotal => new(_time, _securityIdentifier);

        /// <summary>
        /// Liabilities which have occurred, but have not been paid or logged under accounts payable during an accounting period. In other words, obligations for goods and services provided to a company for which invoices have not yet been received; on a Non- Differentiated Balance Sheet.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23495
        /// </remarks>
        [JsonProperty("23495")]
        public AccruedLiabilitiesTotalBalanceSheet AccruedLiabilitiesTotal => new(_time, _securityIdentifier);

        /// <summary>
        /// Collections of cash or other assets related to revenue producing activity for which revenue has not yet been recognized on a Non- Differentiated Balance Sheet.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23496
        /// </remarks>
        [JsonProperty("23496")]
        public DeferredIncomeTotalBalanceSheet DeferredIncomeTotal => new(_time, _securityIdentifier);

        /// <summary>
        /// A future tax liability, resulting from temporary differences between book (accounting) value of assets and liabilities and their tax value or timing differences between the recognition of gains and losses in financial statements, on a Non-Differentiated Balance Sheet.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23497
        /// </remarks>
        [JsonProperty("23497")]
        public DeferredTaxLiabilitiesTotalBalanceSheet DeferredTaxLiabilitiesTotal => new(_time, _securityIdentifier);

        /// <summary>
        /// Reinsurance asset is insurance that is purchased by an insurance company from another insurance company.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23499
        /// </remarks>
        [JsonProperty("23499")]
        public ReinsuranceAssetsBalanceSheet ReinsuranceAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// Deposits made under reinsurance.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23502
        /// </remarks>
        [JsonProperty("23502")]
        public DepositsMadeunderAssumedReinsuranceContractBalanceSheet DepositsMadeunderAssumedReinsuranceContract => new(_time, _securityIdentifier);

        /// <summary>
        /// A contract under which one party (the insurer) accepts significant insurance risk from another party (the policyholder) by agreeing to compensate the policyholder if a specified uncertain future event (the insured event) adversely affects the policyholder. This includes Insurance Receivables and Premiums Receivables.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23503
        /// </remarks>
        [JsonProperty("23503")]
        public InsuranceContractAssetsBalanceSheet InsuranceContractAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// Any type of insurance policy that protects an individual or business from the risk that they may be sued and held legally liable for something such as malpractice, injury or negligence. Liability insurance policies cover both legal costs and any legal payouts for which the insured would be responsible if found legally liable. Intentional damage and contractual liabilities are typically not covered in these types of policies.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23505
        /// </remarks>
        [JsonProperty("23505")]
        public InsuranceContractLiabilitiesBalanceSheet InsuranceContractLiabilities => new(_time, _securityIdentifier);

        /// <summary>
        /// Deposit received through ceded insurance contract.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23508
        /// </remarks>
        [JsonProperty("23508")]
        public DepositsReceivedunderCededInsuranceContractBalanceSheet DepositsReceivedunderCededInsuranceContract => new(_time, _securityIdentifier);

        /// <summary>
        /// Liabilities due on the insurance investment contract.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23509
        /// </remarks>
        [JsonProperty("23509")]
        public InvestmentContractLiabilitiesBalanceSheet InvestmentContractLiabilities => new(_time, _securityIdentifier);

        /// <summary>
        /// Total of the carrying values as of the balance sheet date of obligations incurred through that date and payable for obligations related to services received from employees, such as accrued salaries and bonuses, payroll taxes and fringe benefits. Used to reflect the current portion of the liabilities (due within one year or within the normal operating cycle if longer).
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23515
        /// </remarks>
        [JsonProperty("23515")]
        public PensionAndOtherPostretirementBenefitPlansTotalBalanceSheet PensionAndOtherPostretirementBenefitPlansTotal => new(_time, _securityIdentifier);

        /// <summary>
        /// Liabilities related to an asset classified as held for sale.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23516
        /// </remarks>
        [JsonProperty("23516")]
        public LiabilitiesHeldforSaleTotalBalanceSheet LiabilitiesHeldforSaleTotal => new(_time, _securityIdentifier);

        /// <summary>
        /// A security transaction which expires within a 12 month period that reduces the risk on an existing investment position.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23518
        /// </remarks>
        [JsonProperty("23518")]
        public HedgingAssetsCurrentBalanceSheet HedgingAssetsCurrent => new(_time, _securityIdentifier);

        /// <summary>
        /// Loans that entitles the lender (or the holder of loan debenture) to convert the loan to common or preferred stock (ordinary or preference shares) at a specified rate conversion rate and a specified time frame; in a Non-Differentiated Balance Sheet.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23519
        /// </remarks>
        [JsonProperty("23519")]
        public ConvertibleLoansTotalBalanceSheet ConvertibleLoansTotal => new(_time, _securityIdentifier);

        /// <summary>
        /// Total debt financing obligation issued by a bank or similar financial institution to a company that entitles the lender or holder of the instrument to interest payments and the repayment of principal at a specified time; in a Non-Differentiated Balance Sheet.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23520
        /// </remarks>
        [JsonProperty("23520")]
        public BankLoansTotalBalanceSheet BankLoansTotal => new(_time, _securityIdentifier);

        /// <summary>
        /// Total other loans between the customer and bank which cannot be identified by other specific items in the Debt section; in a Non- Differentiated Balance Sheet.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23521
        /// </remarks>
        [JsonProperty("23521")]
        public OtherLoansTotalBalanceSheet OtherLoansTotal => new(_time, _securityIdentifier);

        /// <summary>
        /// Liabilities related to insurance funds that are dissolved after one year.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23524
        /// </remarks>
        [JsonProperty("23524")]
        public InsuranceFundsNonCurrentBalanceSheet InsuranceFundsNonCurrent => new(_time, _securityIdentifier);

        /// <summary>
        /// The total aggregate of all written promises and/or agreements to repay a stated amount of borrowed funds at a specified date in the future; in a Non-Differentiated Balance Sheet.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23528
        /// </remarks>
        [JsonProperty("23528")]
        public DebtTotalBalanceSheet DebtTotal => new(_time, _securityIdentifier);

        /// <summary>
        /// The treasury stock number of common shares. This represents the number of common shares owned by the company as a result of share repurchase programs or donations.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23529
        /// </remarks>
        [JsonProperty("23529")]
        public ComTreShaNumBalanceSheet ComTreShaNum => new(_time, _securityIdentifier);

        /// <summary>
        /// The treasury stock number of preferred shares. This represents the number of preferred shares owned by the company as a result of share repurchase programs or donations.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23530
        /// </remarks>
        [JsonProperty("23530")]
        public PreTreShaNumBalanceSheet PreTreShaNum => new(_time, _securityIdentifier);

        /// <summary>
        /// This is a metric that shows a company's overall debt situation by netting the value of a company's liabilities and debts with its cash and other similar liquid assets. It is calculated using [Current Debt] + [Long Term Debt] - [Cash and Cash Equivalents].
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23531
        /// </remarks>
        [JsonProperty("23531")]
        public NetDebtBalanceSheet NetDebt => new(_time, _securityIdentifier);

        /// <summary>
        /// The number of authorized shares that is sold to and held by the shareholders of a company, regardless of whether they are insiders, institutional investors or the general public. Unlike shares that are held as treasury stock, shares that have been retired are not included in this figure. The amount of issued shares can be all or part of the total amount of authorized shares of a corporation.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23532
        /// </remarks>
        [JsonProperty("23532")]
        public ShareIssuedBalanceSheet ShareIssued => new(_time, _securityIdentifier);

        /// <summary>
        /// Short term assets set apart for sale to liquidate in the future and are measured at the lower of carrying amount and fair value less costs to sell.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23533
        /// </remarks>
        [JsonProperty("23533")]
        public AssetsHeldForSaleCurrentBalanceSheet AssetsHeldForSaleCurrent => new(_time, _securityIdentifier);

        /// <summary>
        /// Long term assets set apart for sale to liquidate in the future and are measured at the lower of carrying amount and fair value less costs to sell.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23534
        /// </remarks>
        [JsonProperty("23534")]
        public AssetsHeldForSaleNonCurrentBalanceSheet AssetsHeldForSaleNonCurrent => new(_time, _securityIdentifier);

        /// <summary>
        /// Biological assets include plants and animals.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23535
        /// </remarks>
        [JsonProperty("23535")]
        public BiologicalAssetsBalanceSheet BiologicalAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// Cash that the company can use only for specific purposes or cash deposit or placing of owned property by a debtor (the pledger) to a creditor (the pledgee) as a security for a loan or obligation.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23536
        /// </remarks>
        [JsonProperty("23536")]
        public CashRestrictedOrPledgedBalanceSheet CashRestrictedOrPledged => new(_time, _securityIdentifier);

        /// <summary>
        /// A long term loan with a warrant attached that gives the debt holder the option to exchange all or a portion of the loan principal for an equity position in the company at a predetermined rate of conversion within a specified period of time.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23537
        /// </remarks>
        [JsonProperty("23537")]
        public ConvertibleLoansNonCurrentBalanceSheet ConvertibleLoansNonCurrent => new(_time, _securityIdentifier);

        /// <summary>
        /// Financial instruments that are linked to a specific financial instrument or indicator or commodity, and through which specific financial risks can be traded in financial markets in their own right, such as financial options, futures, forwards, etc.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23538
        /// </remarks>
        [JsonProperty("23538")]
        public FinancialOrDerivativeInvestmentCurrentLiabilitiesBalanceSheet FinancialOrDerivativeInvestmentCurrentLiabilities => new(_time, _securityIdentifier);

        /// <summary>
        /// Investments that are neither Investment in Financial Assets nor Long term equity investment, not expected to be cashed within a year.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23540
        /// </remarks>
        [JsonProperty("23540")]
        public OtherInvestmentsBalanceSheet OtherInvestments => new(_time, _securityIdentifier);

        /// <summary>
        /// Amounts due from customers or clients, more than one year from the balance sheet date, for goods or services that have been delivered or sold in the normal course of business, or other receivables.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23541
        /// </remarks>
        [JsonProperty("23541")]
        public TradeAndOtherReceivablesNonCurrentBalanceSheet TradeAndOtherReceivablesNonCurrent => new(_time, _securityIdentifier);

        /// <summary>
        /// For an unclassified balance sheet, carrying amount as of the balance sheet date of obligations due all related parties.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23543
        /// </remarks>
        [JsonProperty("23543")]
        public DueFromRelatedPartiesBalanceSheet DueFromRelatedParties => new(_time, _securityIdentifier);

        /// <summary>
        /// The amount of surplus from insurance contracts which has not been allocated at the balance sheet date. This is represented as a liability to policyholders, as it pertains to cumulative income arising from the with-profits business.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23546
        /// </remarks>
        [JsonProperty("23546")]
        public UnallocatedSurplusBalanceSheet UnallocatedSurplus => new(_time, _securityIdentifier);

        /// <summary>
        /// Debt due under 1 year according to the debt maturity schedule reported by the company.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23547
        /// </remarks>
        [JsonProperty("23547")]
        public DebtDueInYear1BalanceSheet DebtDueInYear1 => new(_time, _securityIdentifier);

        /// <summary>
        /// Debt due under 2 years according to the debt maturity schedule reported by the company.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23548
        /// </remarks>
        [JsonProperty("23548")]
        public DebtDueInYear2BalanceSheet DebtDueInYear2 => new(_time, _securityIdentifier);

        /// <summary>
        /// Debt due within 5 year if the company provide maturity schedule in range e.g. 1-5 years, 2-5 years. Debt due under 5 years according to the debt maturity schedule reported by the company. If a range is reported by the company, the value will be collected under the maximum number of years (eg. 1-5 years, 3-5 years or 5 years will all be collected under this data point.)
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23549
        /// </remarks>
        [JsonProperty("23549")]
        public DebtDueInYear5BalanceSheet DebtDueInYear5 => new(_time, _securityIdentifier);

        /// <summary>
        /// Debt maturing beyond 5 years (eg. 5-10 years) or with no specified maturity, according to the debt maturity schedule reported by the company.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23550
        /// </remarks>
        [JsonProperty("23550")]
        public DebtDueBeyondBalanceSheet DebtDueBeyond => new(_time, _securityIdentifier);

        /// <summary>
        /// Total Debt in Maturity Schedule is the sum of Debt details above.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23551
        /// </remarks>
        [JsonProperty("23551")]
        public TotalDebtInMaturityScheduleBalanceSheet TotalDebtInMaturitySchedule => new(_time, _securityIdentifier);

        /// <summary>
        /// Reserves created by revaluation of assets.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23552
        /// </remarks>
        [JsonProperty("23552")]
        public FixedAssetsRevaluationReserveBalanceSheet FixedAssetsRevaluationReserve => new(_time, _securityIdentifier);

        /// <summary>
        /// Other short term financial liabilities not categorized and due within one year or a normal operating cycle (whichever is longer).
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23553
        /// </remarks>
        [JsonProperty("23553")]
        public CurrentOtherFinancialLiabilitiesBalanceSheet CurrentOtherFinancialLiabilities => new(_time, _securityIdentifier);

        /// <summary>
        /// Other long term financial liabilities not categorized and due over one year or a normal operating cycle (whichever is longer).
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23554
        /// </remarks>
        [JsonProperty("23554")]
        public NonCurrentOtherFinancialLiabilitiesBalanceSheet NonCurrentOtherFinancialLiabilities => new(_time, _securityIdentifier);

        /// <summary>
        /// Other financial liabilities not categorized.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23555
        /// </remarks>
        [JsonProperty("23555")]
        public OtherFinancialLiabilitiesBalanceSheet OtherFinancialLiabilities => new(_time, _securityIdentifier);

        /// <summary>
        /// Total liabilities as reported by the company, may be the same or not the same as Morningstar's standardized definition.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23556
        /// </remarks>
        [JsonProperty("23556")]
        public TotalLiabilitiesAsReportedBalanceSheet TotalLiabilitiesAsReported => new(_time, _securityIdentifier);

        /// <summary>
        /// Total Equity as reported by the company, may be the same or not the same as Morningstar's standardized definition.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 23557
        /// </remarks>
        [JsonProperty("23557")]
        public TotalEquityAsReportedBalanceSheet TotalEquityAsReported => new(_time, _securityIdentifier);

        private readonly DateTime _time;
        private readonly SecurityIdentifier _securityIdentifier;

        /// <summary>
        /// Creates a new instance for the given time and security
        /// </summary>
        public BalanceSheet(DateTime time, SecurityIdentifier securityIdentifier)
        {
            _time = time;
            _securityIdentifier = securityIdentifier;
        }
    }
}
